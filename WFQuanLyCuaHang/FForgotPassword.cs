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
using System.Windows.Input;

namespace WFQuanLyCuaHang
{
    public partial class FForgotPassword : Form
    {
        private DAL db;
        private DBAccount dba;

        private string selectedUsername;
        public FForgotPassword()
        {
            InitializeComponent();
            panel2.Visible = false;
            comboBox1.Visible = false;
            btnFind.Visible = false;
            db = new DAL();
            dba = new DBAccount();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                selectedUsername = comboBox1.SelectedItem.ToString();
                this.ActiveControl = null;
            }
        }

        private void txtEmailOrUser_TextChanged(object sender, EventArgs e)
        {
            string input = txtEmailOrUser.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtEmailOrUser.Text))
            {
                comboBox1.Items.Clear();
                label1.Visible = false;
                return;
            }

            if (input.Contains("@"))
            {
                btnFind.Visible = true;
            }
            else
            {
                btnFind.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = txtEmailOrUser.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Vui lòng nhập Email hoặc Tên đăng nhập.");
                return;
            }
            if (btnFind.Visible == true)
            {
                input = selectedUsername;
            }
            string sql = "SELECT Username, Email, VerificationCode FROM Account WHERE Username  = @username";
            SqlParameter parameter = new SqlParameter("@username", SqlDbType.NVarChar);
            parameter.Value = input;
            DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text, parameter);
            // Kiểm tra xem ds có dữ liệu không
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string email = ds.Tables[0].Rows[0]["Email"].ToString();
                string username = ds.Tables[0].Rows[0]["Username"].ToString();
                string verificationCode = dba.GenerateVerificationCode();
                dba.SendVerificationEmail(email, verificationCode);
                string err = string.Empty;
                dba.SaveVerificationCodeToDatabase(ref err, username, verificationCode);
                if (!string.IsNullOrEmpty(err))
                {
                    MessageBox.Show("Error saving verification code: " + err);
                }
                panel2.Visible = true;
                button3.Enabled = false;
                MessageBox.Show("Mã xác nhận đã được gửi đến email của bạn.");
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại. Vui lòng kiểm tra lại thông tin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //FormLogin fLogin = new FormLogin();
                //fLogin.Show();
                Application.Exit();
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = txtEmailOrUser.Text.Trim();
            // Input là email
            string sql = "SELECT Username, Email, VerificationCode FROM Account WHERE Email = @Email";
            SqlParameter parameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            parameter.Value = input;

            DataSet ds = db.ExecuteQueryDataSet(sql, CommandType.Text, parameter);

            // Kiểm tra xem ds có dữ liệu không
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    comboBox1.Items.Add(row["Username"].ToString());
                }
                comboBox1.Visible = true;
                MessageBox.Show("Chọn username tài khoản của bạn.");
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản nào với email này.");
                comboBox1.Visible = false;
            }
        }

        private void FForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtEmailOrUser.Text.Trim();
            string enteredCode = textBox1.Text;

            if (string.IsNullOrWhiteSpace(enteredCode))
            {
                MessageBox.Show("Vui lòng nhập mã xác nhận.");
                return;
            }
            if(btnFind.Visible == true)
            {
                input = selectedUsername;
            }
            string sql = "SELECT Username, Email, VerificationCode FROM Account WHERE Username = @username";
            SqlParameter parameter = new SqlParameter("@username", SqlDbType.NVarChar);
            parameter.Value = input;
            DataSet dataSet = db.ExecuteQueryDataSet(sql, CommandType.Text, parameter);
            // Kiểm tra xem ds có dữ liệu không
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow account = dataSet.Tables[0].Rows[0];
                string vertification = account["VerificationCode"].ToString();
                string username = account["Username"].ToString();
                if (vertification == enteredCode)
                {
                    this.Close();
                    FResetPassword resetForm = new FResetPassword(username);
                    resetForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Mã xác nhận không chính xác. Vui lòng thử lại.");
                }
            }
            else
            {
                MessageBox.Show($"Tài khoản {input} không tồn tại. Vui lòng kiểm tra lại thông tin.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin fLogin = new FormLogin();
            fLogin.Show();
        }

        private void txtEmailOrUser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();
            }
        }
    }
}
