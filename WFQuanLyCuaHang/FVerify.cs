using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WFQuanLyCuaHang
{
    public partial class FVerify: Form
    {
        private DAL db;
        private DBAccount dba;
        private DBCustomer dbc;

        private string username;
        private string fullname;
        private DateTime lastResendTime;
        private Timer resendTimer;
        private int remainingSeconds;
        private string email;

        // Event to notify when verification is successful
        public event Action OnVerificationSuccess;
        public FVerify(string username, string fullname, string email)
        {
            InitializeComponent();
            this.username = username;
            this.fullname = fullname;
            this.email = email;
            resendTimer = new Timer();
            resendTimer.Interval = 1000;
            resendTimer.Tick += ResendTimer_Tick;
            lblTimer.Visible = false;

            this.db = new DAL();
            this.dba = new DBAccount();
            this.dbc = new DBCustomer();

        }

        private void FVerify_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn chưa nhập mã xác nhận xong.\n" +
                "Bạn có chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();
        }
        private void ResendTimer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;
            if (remainingSeconds <= 0)
            {
                txtResend.Enabled = true;
                lblTimer.Visible = false;
                resendTimer.Stop();
            }
            else
            {
                lblTimer.Text = $"{remainingSeconds}";
            }
        }
        private void txtResend_Click(object sender, EventArgs e)
        {
            // Chặn click nếu chưa đủ thời gian
            if ((DateTime.Now - lastResendTime).TotalSeconds < 90)
            {
                MessageBox.Show("Bạn chỉ có thể yêu cầu mã xác nhận mới sau 90 giây.");
                return;
            }

            txtResend.Enabled = false; // Vô hiệu ngay để tránh spam

            try
            {
                if (!CheckAccountExists(username))
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    txtResend.Enabled = true;
                    return;
                }

                string newCode = dba.GenerateVerificationCode();

                // Cập nhật mã xác nhận mới
                bool updated = UpdateVerificationCode(username, newCode, DateTime.Now.AddMinutes(5));
                if (!updated)
                {
                    MessageBox.Show("Cập nhật mã xác nhận thất bại.");
                    txtResend.Enabled = true;
                    return;
                }

                bool sent = dba.SendVerificationEmail(email, newCode);
                if (!sent)
                {
                    MessageBox.Show("Gửi email thất bại. Vui lòng thử lại.");
                    txtResend.Enabled = true;
                    return;
                }

                MessageBox.Show("Mã xác nhận mới đã được gửi đến email của bạn.");

                // Khởi động đếm ngược
                StartResendTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                txtResend.Enabled = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string enteredCode = txtVerificationCode.Text;
            string error = string.Empty; // Declare the error variable

            // Lấy thông tin tài khoản từ DB
            string query = "SELECT AccountID, UserType, CustomerID, EmployeeID, VerificationCode, VerificationCodeExpiration FROM Account WHERE Username = @username";
            SqlParameter param = new SqlParameter("@username", username);
            DataTable accountTable = db.ExecuteQueryDataTable(query, CommandType.Text, param);

            // Kiểm tra xem tài khoản có tồn tại không
            if (accountTable.Rows.Count > 0)
            {
                // Đọc dữ liệu từ DataTable
                DataRow accountRow = accountTable.Rows[0];
                int accountId = Convert.ToInt32(accountRow["AccountID"]);
                string verificationCode = accountRow["VerificationCode"].ToString();
                DateTime expirationTime = Convert.ToDateTime(accountRow["VerificationCodeExpiration"]);

                // 2Kiểm tra mã xác nhận
                if (enteredCode == verificationCode)
                {
                    if (expirationTime > DateTime.Now)
                    {

                        string result = dba.UpdateAccountStatusToActive(username);
                        Console.WriteLine("Kết quả cập nhật trạng thái: " + result);
                        if (result == "Cập nhật trạng thái thành công!")
                        {
                            //string createUserResult = dba.CreateCustomer(username, fullname, null, null);
                            bool createUserResult = dbc.AddCustomer(ref error, fullname, null, null);
                            string getCustomerIdQuery = "SELECT TOP 1 CustomerID FROM Customer ORDER BY CustomerID DESC";
                            DataTable customerIdTable = db.ExecuteQueryDataTable(getCustomerIdQuery, CommandType.Text);

                            string customerID = string.Empty;
                            if (customerIdTable.Rows.Count > 0)
                            {
                                customerID = customerIdTable.Rows[0]["CustomerID"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy CustomerID.");
                                return;
                            }
                            if (createUserResult)
                            {
                                Console.WriteLine("Kết quả tạo User: " + createUserResult);
                                //update customerID in account
                                if (accountRow["UserType"].ToString() == "Admin")
                                {
                                }
                                else
                                {
                                    dba.UpdateAccount(ref error, accountId, null, null, customerID);
                                }
                                OnVerificationSuccess?.Invoke();
                                MessageBox.Show("Xác nhận thành công. Tài khoản đã được kích hoạt.");
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show($"Không thể tạo User: {createUserResult}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật trạng thái thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã xác nhận đã hết hạn. Vui lòng yêu cầu mã mới.");
                    }
                }
                else
                {
                    MessageBox.Show("Mã xác nhận không chính xác. Vui lòng thử lại.");
                }

            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }
        }
        private bool CheckAccountExists(string username)
        {
            string sql = "SELECT COUNT(*) FROM Account WHERE Username = @username";
            SqlParameter param = new SqlParameter("@username", username);
            DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text, param);

            return ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0;
        }

        private bool UpdateVerificationCode(string username, string code, DateTime expiration)
        {
            string sql = "UPDATE Account SET VerificationCode = @code, VerificationCodeExpiration = @exp WHERE Username = @username";
            SqlParameter[] parameters = {
        new SqlParameter("@code", code),
        new SqlParameter("@exp", expiration),
        new SqlParameter("@username", username)
        };
            string err = string.Empty;
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err, parameters);
        }

        private void StartResendTimer()
        {
            lastResendTime = DateTime.Now;
            remainingSeconds = 90;
            lblTimer.Visible = true;
            lblTimer.Text = $"{remainingSeconds}";
            resendTimer.Start();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
