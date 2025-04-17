using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using DataAccessLayer;
using System.Configuration;

namespace BusinessLogicLayer
{
    public class DBAccount
    {
        private DAL db;
        private DBCustomer dbCustomer;

        public DBAccount()
        {
            db = DALManager.Instance; // sử dụng DAL singleton
            dbCustomer = new DBCustomer(); // giả sử DBCustomer cũng sử dụng DALManager bên trong
        }

        public bool AddAccount(ref string err, string username, string password, string userType, string email, string salt, string verificationCode, DateTime? verificationCodeExpiration, int? employeeID, int? customerID)
        {
            return db.MyExecuteNonQuery("spAddAccount", CommandType.StoredProcedure, ref err,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@UserType", userType),
                new SqlParameter("@Email", email),
                new SqlParameter("@Salt", salt),
                new SqlParameter("@VerificationCode", verificationCode),
                new SqlParameter("@VerificationCodeExpiration", (object)verificationCodeExpiration ?? DBNull.Value),
                new SqlParameter("@EmployeeID", (object)employeeID ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object)customerID ?? DBNull.Value));
        }

        public bool UpdateAccount(ref string err, int accountID, string newPassword, string employeeID, string customerID)
        {
            try
            {
                return db.MyExecuteNonQuery("spUpdateAccount", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@AccountID", accountID),
                    new SqlParameter("@Password", newPassword),
                    new SqlParameter("@EmployeeID", (object)employeeID ?? DBNull.Value),
                    new SqlParameter("@CustomerID", (object)customerID ?? DBNull.Value));
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool UpdateAccountInfo(ref string err, int accountID, string username, string email, string userType, string employeeID, string customerID, string status)
        {
            return db.MyExecuteNonQuery("spUpdateAccount", CommandType.StoredProcedure, ref err,
                new SqlParameter("@AccountID", accountID),
                new SqlParameter("@Username", username),
                new SqlParameter("@Email", email),
                new SqlParameter("@UserType", userType),
                new SqlParameter("@EmployeeID", (object)employeeID ?? DBNull.Value),
                new SqlParameter("@CustomerID", (object)customerID ?? DBNull.Value),
                new SqlParameter("@Status", status));
        }

        public bool DeleteAccount(ref string err, int accountID)
        {
            return db.MyExecuteNonQuery("spDeleteAccount", CommandType.StoredProcedure, ref err,
                new SqlParameter("@AccountID", accountID));
        }

        public DataSet GetAccountList()
        {
            return db.ExecuteQueryDataSet("spGetAccount", CommandType.StoredProcedure, null);
        }

        public string GenerateVerificationCode(int length = 6)
        {
            Random random = new Random();
            string code = "";
            for (int i = 0; i < length; i++)
                code += random.Next(0, 10).ToString();
            return code;
        }

        public bool SaveVerificationCodeToDatabase(ref string err, string username, string verificationCode)
        {
            DateTime expiration = DateTime.Now.AddMinutes(5);
            return db.MyExecuteNonQuery("spSaveVerificationCode", CommandType.StoredProcedure, ref err,
                new SqlParameter("@Username", username),
                new SqlParameter("@VerificationCode", verificationCode),
                new SqlParameter("@Expiration", expiration));
        }

        public bool SendVerificationEmail(string recipientEmail, string verificationCode)
        {
            string senderEmail = ConfigurationManager.AppSettings["GmailSender"];
            string senderPassword = ConfigurationManager.AppSettings["GmailAppPassword"];

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true,
                };

                MailMessage message = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "Mã xác nhận tài khoản",
                    Body = $"Xin chào bạn,\nMã xác nhận của bạn là: {verificationCode}\n(Mã có hiệu lực 5 phút)"
                };

                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi gửi mail: " + ex.Message);
                return false;
            }
        }

        public string UpdateAccountStatusToActive(string username)
        {
            try
            {
                string sql = "UPDATE Account SET Status = 1 WHERE Username = @Username";
                SqlParameter param = new SqlParameter("@Username", username);
                string error = "";

                bool updated = db.MyExecuteNonQuery(sql, CommandType.Text, ref error, param);

                return updated ? "Cập nhật trạng thái thành công!" : "Tài khoản không tồn tại!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public DataTable GetUserInfoByUsername(string username, ref string err)
        {
            try
            {
                return db.ExecuteQueryDataTable("spGetUserInfoByUsername", CommandType.StoredProcedure,
                    new SqlParameter("@Username", username));
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }

        public DataTable GetOrdersByCustomerUsername(string username, ref string err)
        {
            try
            {
                return db.ExecuteQueryDataTable("spGetOrdersByCustomerUsername", CommandType.StoredProcedure,
                    new SqlParameter("@Username", username));
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }

        public bool CreateDatabaseUser(ref string err, string username, string password, string userType)
        {
            return db.MyExecuteNonQuery("CreateUserIfNotExists", CommandType.StoredProcedure, ref err,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@UserType", userType));
        }
    }
}
