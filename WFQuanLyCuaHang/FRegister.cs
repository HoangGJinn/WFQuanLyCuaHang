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
    public partial class FRegister : Form
    {
        DBAccount db = new DBAccount();
        public FRegister()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            txtCFPass.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //back to login
        private void label10_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FormLogin f = new FormLogin();
            f.Show();
        }

        //btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtCFPass.Text = "";
        }

        //btn Exit
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Transparent;
        }
        //

        private void btnReg_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string fullname = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPass.Text;
            string confirmPassword = txtCFPass.Text;

            if (string.IsNullOrWhiteSpace(username) 
                || string.IsNullOrWhiteSpace(fullname) 
                ||string.IsNullOrWhiteSpace(email) 
                || string.IsNullOrWhiteSpace(password) 
                || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.");
                return;
            }
            //check valid email
            try
            {
                var mail = new System.Net.Mail.MailAddress(email.Trim());
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ.");
                return;
            }

            // query
            string sql = "SELECT COUNT(*) AS UserCount FROM Account WHERE Username = @username";
            SqlParameter param = new SqlParameter("@username", username);


            // Sử dụng lớp DAL để thực hiện truy vấn và nhận kết quả dưới dạng DataSet
            DataTable ds = new DAL().ExecuteQueryDataTable(sql, CommandType.Text, param);

            // Kiểm tra kết quả trả về
            if (ds.Rows.Count > 0 && Convert.ToInt32(ds.Rows[0]["UserCount"]) > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.");
                return;
            }

            // Nếu chưa tồn tại, tiếp tục
            string salt = CPass.GenerateSalt();
            string hashedPassword = CPass.HashPasswordWithSalt(password, salt);
            string err = string.Empty;
            string usertype = "";

            // Đếm tổng số người dùng
            string sqlUserCount = "SELECT COUNT(*) AS UserCount FROM Account";
            DataTable dtUserCount = new DAL().ExecuteQueryDataTable(sqlUserCount, CommandType.Text);

            // Nếu tạo lần đầu thì là admin
            int count = 0;
            if (dtUserCount.Rows.Count > 0)
            {
                count = Convert.ToInt32(dtUserCount.Rows[0]["UserCount"]);
            }
            usertype = count == 0 ? "Admin" : "Customer";

            bool isSuccess = db.AddAccount(ref err, username, hashedPassword, usertype, email, salt, null, null, null, null);

            if (isSuccess)
            {
                MessageBox.Show("Đăng ký thành công.");

                bool createUserResult = db.CreateDatabaseUser(ref err, username, password, usertype);
                if (!createUserResult)
                {
                    MessageBox.Show("Tạo login SQL thất bại: " + err);
                }

                string verificationCode = db.GenerateVerificationCode();
                db.SendVerificationEmail(email, verificationCode);
                db.SaveVerificationCodeToDatabase(ref err, username, verificationCode);
                FVerify verifyForm = new FVerify(username, fullname, email);
                verifyForm.OnVerificationSuccess += FormRegister_OnVerificationSuccess;
                verifyForm.ShowDialog();
            }

            else
            {
                MessageBox.Show("Đăng ký thất bại: " + err);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtCFPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnReg.PerformClick(); // Kích hoạt sự kiện click của nút đăng ký
            }
        }

        private void FormRegister_OnVerificationSuccess()
        {
            // Khi sự kiện OnVerificationSuccess được gọi, đóng form đăng ký
            this.Close(); // Đóng form đăng ký nếu bạn đang làm việc với form đăng ký từ FVerify
            FormLogin f = new FormLogin();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
