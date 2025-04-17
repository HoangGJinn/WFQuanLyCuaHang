using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FEmployeeAccount : Form
    {
        private string username;
        private DBAccount dba;
        public FEmployeeAccount(string username)
        {
            InitializeComponent();
            dba = new DBAccount();
            this.username = username;
            lbHello.Text = "Hello Employee " + username;
        }

        private void FEmployeeAccount_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            //MessageBox.Show(username); // kiểm tra có đúng username không

            string error = "";
            DataTable dt = dba.GetUserInfoByUsername(username, ref error);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtUsername.Text = row["Username"].ToString();
                txtFullName.Text = row["FullName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtAddress.Text = row["Address"].ToString();
                txtSalary.Text = row["Salary"].ToString();
                txtPosition.Text = row["Position"].ToString();
                txtHireDate.Text = row["HireDate"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản.");
            }
        }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitter2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
