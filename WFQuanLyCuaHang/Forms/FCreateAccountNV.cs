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
using WFQuanLyCuaHang.Common;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FCreateAccountNV : Form
    {
        private DAL db;
        private DBAccount dba;
        private DBEmployee dbe;
        public FCreateAccountNV()
        {
            InitializeComponent();
            dba = new DBAccount();
            dbe = new DBEmployee();
            db = DALManager.Instance;
        }

        private void FCreateAccountNV_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            txtCFPass.PasswordChar = '*';
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            int employeeID = txtEmployeeID.Text == "" ? 0 : Convert.ToInt32(txtEmployeeID.Text);
            string email = txtEmail.Text;
            string password = txtPass.Text;
            string confirmPassword = txtCFPass.Text;

            if (string.IsNullOrWhiteSpace(username)
                || string.IsNullOrWhiteSpace(txtEmployeeID.Text)
                || string.IsNullOrWhiteSpace(email)
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
            DataTable ds = db.ExecuteQueryDataTable(sql, CommandType.Text, param);

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


            bool isSuccess = dba.AddAccount(ref err, username, hashedPassword, "Employee", email, salt, null, null, employeeID, null);
            //update status
            if (isSuccess)
            {
                bool createUserResult = dba.CreateDatabaseUser(ref err, username, password, "Employee");
                if (!createUserResult)
                {
                    MessageBox.Show("Tạo login SQL thất bại: " + err);
                }
                dba.UpdateAccountStatusToActive(username);
                MessageBox.Show("Tạo tài khoản thành công!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thất bại: " + err);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCFPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnReg_Click(sender, e);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtEmployeeID.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtCFPass.Text = "";
        }
    }
}
