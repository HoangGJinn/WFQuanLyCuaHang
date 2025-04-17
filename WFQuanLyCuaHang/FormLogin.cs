using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using Guna.UI2.WinForms;
using System.Data.SqlClient;
using DataAccessLayer;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WFQuanLyCuaHang.Common;

namespace WFQuanLyCuaHang
{
    public partial class FormLogin : Form
    {
        List<Image> images = new List<Image>();
        string[] location = new string[25];
        public string username { get; private set; }
        public string usertype { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            tounage();
        
        }

        private void tounage()
        {
            images.Add(Properties.Resources.textbox_user_1);
            images.Add(Properties.Resources.textbox_user_2);
            images.Add(Properties.Resources.textbox_user_3);
            images.Add(Properties.Resources.textbox_user_4);
            images.Add(Properties.Resources.textbox_user_5);
            images.Add(Properties.Resources.textbox_user_6);
            images.Add(Properties.Resources.textbox_user_7);
            images.Add(Properties.Resources.textbox_user_8);
            images.Add(Properties.Resources.textbox_user_9);
            images.Add(Properties.Resources.textbox_user_10);
            images.Add(Properties.Resources.textbox_user_11);
            images.Add(Properties.Resources.textbox_user_12);
            images.Add(Properties.Resources.textbox_user_13);
            images.Add(Properties.Resources.textbox_user_14);
            images.Add(Properties.Resources.textbox_user_15);
            images.Add(Properties.Resources.textbox_user_16);
            images.Add(Properties.Resources.textbox_user_17);
            images.Add(Properties.Resources.textbox_user_18);
            images.Add(Properties.Resources.textbox_user_19);
            images.Add(Properties.Resources.textbox_user_20);
            images.Add(Properties.Resources.textbox_user_21);
            images.Add(Properties.Resources.textbox_user_22);
            images.Add(Properties.Resources.textbox_user_23);
            images.Add(Properties.Resources.textbox_user_24);
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query lấy salt & hashed password của tài khoản nếu tồn tại
            string sql = "SELECT Salt, Password, UserType, Status FROM Account WHERE Username = @username";
            SqlParameter param = new SqlParameter("@username", username);

            // Thực thi và lấy kết quả
            DataTable dt = new DAL().ExecuteQueryDataTable(sql, CommandType.Text, param);

            // Kiểm tra xem user có tồn tại không
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                return;
            }

            // Lấy giá trị salt và password and Role từ bảng
            string salt = dt.Rows[0]["Salt"].ToString();
            string storedHashedPassword = dt.Rows[0]["Password"].ToString();
            usertype = dt.Rows[0]["UserType"].ToString();

            // Hash lại mật khẩu người dùng nhập vào
            string hashedPassword = CPass.HashPasswordWithSalt(password, salt);

            if(hashedPassword != storedHashedPassword)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.");
                return;
            }
            // Kiểm tra trạng thái tài khoản
            int status = Convert.ToInt32(dt.Rows[0]["Status"]);
            if (status == 0)
            {
                MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị viên.");
                return;
            }

            // Tạo chuỗi kết nối và lưu vào SessionContext
            string connStr = $"Data Source=.;Initial Catalog=LaptopStore2;User ID={username};Password={password};";

            // Lưu vào SessionContext
            SessionContext.CurrentUsername = username;
            SessionContext.CurrentUserType = usertype;
            SessionContext.ConnectionString = connStr;

            DALManager.Reset(); // Đảm bảo DAL chưa bị giữ instance cũ
            // Khởi tạo DAL duy nhất
            DALManager.Initialize(connStr);


            if (chkRemember.Checked)
            {
                Properties.Settings.Default.Username = username;
                Properties.Settings.Default.Password = password;
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
            FormMainMenu fMain = new FormMainMenu(username, usertype);
            this.Hide();
            fMain.Show();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;

                chkRemember.Checked = true;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Tạo màu gradient từ màu xanh dương sang màu tím
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.Black,  // Màu bắt đầu
                Color.DarkSlateBlue,// Màu kết thúc
                LinearGradientMode.Vertical)) // Kiểu gradient dọc
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.textbox_password; 
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            int length = txtUsername.Text.Length;

            if (length > 0 && length < images.Count)
            {
                pictureBox2.Image = images[length - 1]; // Hiển thị ảnh tương ứng với số ký tự
            }
            else if (length == 0)
            {
                pictureBox2.Image = Properties.Resources.debut; // Ảnh mặc định khi chưa nhập gì
            }
            else
            {
                pictureBox2.Image = images[images.Count - 1]; // Hiển thị ảnh cuối cùng nếu nhập quá nhiều
            }

            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Transparent;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FRegister f = new FRegister();
            this.Hide();
            f.Show();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick(); // Kích hoạt sự kiện click của nút đăng ký
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FForgotPassword fForgotPassword = new FForgotPassword();
            fForgotPassword.ShowDialog();
        }
    }
}
