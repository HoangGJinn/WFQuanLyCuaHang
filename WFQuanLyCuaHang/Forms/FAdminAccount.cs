using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FAdminAccount: Form
    {
        private DBAccount dba;
        bool isEditting = false;
        public FAdminAccount()
        {
            InitializeComponent();
            dba = new DBAccount();
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            dgvAccount.AutoGenerateColumns = false;
            LoadData();
        }

        void LoadData()
        {
            try
            {
                DataSet ds = dba.GetAccountList();
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Xóa trống các đối tượng trong Panel
                    txtAccountID.Clear();
                    txtUsername.Clear();
                    txtUsertype.Clear();
                    txtEmail.Clear();
                    txtStatus.Clear();
                    txtVerificationCode.Clear();
                    txtVCE.Clear();
                    txtEmployeeID.Clear();
                    txtCustomerID.Clear();

                    //disable all text box
                    pnl1.Enabled = false;

                    //enable button
                    btnCreate.Enabled = true;

                    // Đổ dữ liệu vào DataGridView
                    dgvAccount.DataSource = ds.Tables[0];
                    dgvAccount.CellClick += new DataGridViewCellEventHandler(dgvAccount_CellClick);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            //change color
            if(txtEmployeeID.Text != "")
                txtEmployeeID.FillColor = Color.LightGreen;
            else
                txtEmployeeID.FillColor = Color.White;
        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cho thao tac tren cac nut Sua / Xoa
            this.btnEdit.Enabled = true;
            this.btnDel.Enabled = true;
            if (!isEditting)
            {
                pnl1.Enabled = false;
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                pnl1.Enabled = true;
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
            int r = dgvAccount.CurrentCell.RowIndex;
            txtAccountID.Text = dgvAccount.Rows[r].Cells[0].Value.ToString();
            txtUsername.Text = dgvAccount.Rows[r].Cells[1].Value.ToString();
            txtUsertype.Text = dgvAccount.Rows[r].Cells[2].Value.ToString();
            txtEmail.Text = dgvAccount.Rows[r].Cells[3].Value.ToString();
            txtStatus.Text = dgvAccount.Rows[r].Cells[8].Value.ToString();
            txtVerificationCode.Text = dgvAccount.Rows[r].Cells[4].Value.ToString();
            txtVCE.Text = dgvAccount.Rows[r].Cells[5].Value.ToString(); //Verification Code Expiration
            txtEmployeeID.Text = dgvAccount.Rows[r].Cells[6].Value.ToString();
            txtCustomerID.Text = dgvAccount.Rows[r].Cells[7].Value.ToString();
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            //change color
            if (txtCustomerID.Text != "")
                txtCustomerID.FillColor = Color.LightGreen;
            else
                txtCustomerID.FillColor = Color.White;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FCreateAccountNV f = new FCreateAccountNV();
            f.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.No)
                return;
            string err = string.Empty;
            if (dba.DeleteAccount(ref err, int.Parse(txtAccountID.Text)))
            {
                MessageBox.Show("Xóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditting = true;

            //
            pnl1.Enabled = true;

            txtAccountID.Enabled = false;
            txtVerificationCode.Enabled = false;
            txtVCE.Enabled = false;
            btnCreate.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;

        }

        private void pnl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAccountID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCustomerID_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVerificationCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVCE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsertype_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int accountID = txtAccountID.Text == "" ? 0 : int.Parse(txtAccountID.Text);
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string usertype = txtUsertype.Text;
            string employeeID = txtEmployeeID.Text;
            string customerID = txtCustomerID.Text;
            string status = txtStatus.Text;

            if (string.IsNullOrWhiteSpace(employeeID))
            {
                employeeID = null;
            }
            if (string.IsNullOrWhiteSpace(customerID))
            {
                customerID = null;
            }
            if (!string.IsNullOrEmpty(employeeID) && !string.IsNullOrEmpty(customerID))
            {
                MessageBox.Show("Chỉ được chọn một trong hai trường Nhân viên hoặc Khách hàng.");
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(usertype) || string.IsNullOrWhiteSpace(txtAccountID.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem username đã tồn tại ở tài khoản khác chưa
            string sql = "SELECT COUNT(*) AS UserCount FROM Account WHERE Username = @username AND AccountID != @accountID";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@username", username),
        new SqlParameter("@accountID", accountID)
            };

            DataTable ds = new DAL().ExecuteQueryDataTable(sql, CommandType.Text, parameters);

            if (ds.Rows.Count > 0 && Convert.ToInt32(ds.Rows[0]["UserCount"]) > 0)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu chưa tồn tại, tiếp tục cập nhật
            string err = string.Empty;
            bool isSuccess = dba.UpdateAccountInfo(ref err, accountID, username, email, usertype, employeeID, customerID, status);

            if (isSuccess)
            {
                MessageBox.Show("Cập nhật tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            isEditting = false;

            btnCreate.Enabled = true;
            btnDel.Enabled = true;
            btnEdit.Enabled = true;

            //
            txtAccountID.Clear();
            txtUsername.Clear();
            txtUsertype.Clear();
            txtEmail.Clear();
            txtStatus.Clear();
            txtVerificationCode.Clear();
            txtVCE.Clear();
            txtEmployeeID.Clear();
            txtCustomerID.Clear();
        }
    }
}
