using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FCustomerAccount: Form
    {
        private string username;
        private DBAccount dba;
        public FCustomerAccount(string username)
        {
            InitializeComponent();
            this.username = username;
            dba = new DBAccount();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FCustomerAccount_Load(object sender, EventArgs e)
        {
            LoadInfo();
            LoadOrder();
            lbHello.Text = "Hello " + username;
        }
        void LoadInfo()
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
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin tài khoản.");
            }
        }

        private void LoadOrder()
        {
            string error = "";
            DataTable dt = dba.GetOrdersByCustomerUsername(username, ref error);
            if (dt != null && dt.Rows.Count > 0)
            {
                //dgvOrder.AutoGenerateColumns = false; // Tắt tự động sinh cột
                lbTotal.Text = "Total: " + dt.Rows.Count.ToString();

                dgvOrder.DataSource = dt;
                dgvOrder.Columns["OrderDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvOrder.Columns["TotalAmount"].DefaultCellStyle.Format = "#,##0₫";
                dgvOrder.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin đơn hàng.");
            }
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
