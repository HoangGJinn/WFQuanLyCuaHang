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
    public partial class FCreateImport : Form
    {
        DBAccount dba;
        DBEmployee dbe;
        DBImport dbi;
        DBImportDetail dbid;
        List<CartItem> cart;
        string username;
        string usertype;
        decimal totalCost;

        public bool OrderPlacedSuccessfully = false;

        public FCreateImport(List<CartItem> cart, string username, string usertype, decimal totalCost)
        {
            InitializeComponent();
            this.cart = cart;
            this.username = username;
            this.usertype = usertype;
            this.totalCost = totalCost;
            dbi = new DBImport();
            dba = new DBAccount();
            dbid = new DBImportDetail();
            dbe = new DBEmployee();


            lbTotalAmount.Text = "Tổng tiền: " + totalCost.ToString("N0") + "đ";
        }

        private void FCreateImport_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }

        private void lbPayment_Click(object sender, EventArgs e)
        {

        }

        private void cbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lbTotalAmount_Click(object sender, EventArgs e)
        {

        }
        //Get EmployeeID
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cbEmployeeID.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            int employeeID = Convert.ToInt32(cbEmployeeID.SelectedValue);
            if (employeeID == -1)
            {
                MessageBox.Show("Không thể xác định thông tin nhân viên. Vui lòng kiểm tra lại dữ liệu người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime importDate = dtpImportDate.Value;
            string err = "";
            int newImportID = 0;

            if (cart == null || cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống. Vui lòng thêm sản phẩm trước khi nhập hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Chuyển cart sang danh sách ImportDetail
                List<DBImport.ImportDetail> importDetails = cart.Select(item => new DBImport.ImportDetail
                {
                    ProductID = item.ProductID,
                    SupplierID = item.SupplierID,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList();

                // Gọi hàm trong BAL
                bool result = dbi.CreateFullImport(ref err, employeeID, importDate, totalCost, importDetails, ref newImportID);

                if (result)
                {
                    MessageBox.Show($"Nhập hàng thành công! Mã nhập hàng: {newImportID}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OrderPlacedSuccessfully = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nhập hàng thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nhập hàng thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadEmployeeList()
        {
            DataSet ds = dbe.GetEmployees();
            if (ds != null && ds.Tables.Count > 0)
            {
                cbEmployeeID.DataSource = ds.Tables[0];
                cbEmployeeID.DisplayMember = "FullName";  // Cột bạn muốn hiển thị
                cbEmployeeID.ValueMember = "EmployeeID";      // Cột dùng để lấy ID
                cbEmployeeID.SelectedIndex = -1; // Đặt ban đầu là chưa chọn
            }
            else
            {
                MessageBox.Show("Không thể tải danh sách khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
