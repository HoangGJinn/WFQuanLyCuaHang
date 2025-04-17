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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WFQuanLyCuaHang
{
    public partial class FResetPassword : Form
    {
        private string username;
        private DAL db;
        private DBAccount dba;
        public FResetPassword(string username)
        {
            InitializeComponent();
            this.username = username;
            db = new DAL();
            dba = new DBAccount();
            txtPassReset.PasswordChar = '*';
            txtCFPass2.PasswordChar = '*';

        }

        private void FResetPassword_Load(object sender, EventArgs e)
        {
            label1.Text = "Hello, " + username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn chưa tạo lại mật khẩu, bạn có chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassReset.PasswordChar = '\0';
                txtCFPass2.PasswordChar = '\0';
            }
            else
            {
                txtPassReset.PasswordChar = '*';
                txtCFPass2.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newPassword = txtPassReset.Text.Trim();
            string confirmPassword = txtCFPass2.Text.Trim();
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu mới và xác nhận mật khẩu.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp.");
                return;
            }

            string sql = "SELECT * FROM Account WHERE Username = @username";
            SqlParameter parameter = new SqlParameter("@username", username);
            DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text, parameter);
            if(ds != null) {
                if (ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi truy vấn tài khoản.");
                return;
            }
            string salt = ds.Tables[0].Rows[0]["Salt"].ToString();

            string hashedPassword = CPass.HashPasswordWithSalt(newPassword, salt);
            string err = string.Empty;
            int accountID = Convert.ToInt32(ds.Tables[0].Rows[0]["AccountID"]);
            dba.UpdateAccount(ref err, accountID, hashedPassword, null, null);
            MessageBox.Show("Đặt lại mật khẩu thành công!");
            this.Close();
            FormLogin fLogin = new FormLogin();
            fLogin.Show();
        }
    }
}
