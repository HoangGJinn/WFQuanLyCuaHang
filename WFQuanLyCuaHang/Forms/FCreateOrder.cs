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
    public partial class FCreateOrder : Form
    {
        DBAccount dba;
        DBCustomer dbc;
        DBOrder dbo;
        List<CartItem> cart;
        string username;
        string usertype;
        decimal totalAmount;

        public bool OrderPlacedSuccessfully = false;

        public FCreateOrder(List<CartItem> cart, string username, string usertype, decimal totalAmount)
        {
            InitializeComponent();
            this.cart = cart;
            this.username = username;
            this.usertype = usertype;
            this.totalAmount = totalAmount;
            dbo = new DBOrder();
            dba = new DBAccount();
            dbc = new DBCustomer();

            lbTotalAmount.Text = "Tổng tiền: " + totalAmount.ToString("N0") + "đ";
        }

        private void FCreateOrder_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
            LoadPaymentMethods();
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
        private int LoadEmployeeID()
        {
            string error = "";
            DataTable dt = dba.GetUserInfoByUsername(username, ref error);
            if (dt != null && dt.Rows.Count > 0)
            {
                int employeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                // Sử dụng employeeID nếu cần
                return employeeID;
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Return a default value if no employee ID is found
        }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (cbCustomerID.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ giao hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPayment.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ form
            int customerID = Convert.ToInt32(cbCustomerID.SelectedValue); // giả sử cbCustomerID đã gán ValueMember = CustomerID
            int employeeID = LoadEmployeeID();
            if (employeeID == -1)  // Kiểm tra trường hợp employeeID là -1
            {
                MessageBox.Show("Không thể xác định thông tin nhân viên. Vui lòng kiểm tra lại dữ liệu người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;  // Ngừng thực hiện nếu không có employeeID hợp lệ
            }
            DateTime orderDate = dtpOrderDate.Value;
            string shippingAddress = txtAddress.Text;
            string paymentMethod = cbPayment.Text;


            string err = "";
            int newOrderID = 0;

            // Chuyển cart sang danh sách OrderDetail
            List<DBOrder.OrderDetail> orderDetails = cart.Select(item => new DBOrder.OrderDetail
            {
                ProductID = item.ProductID,
                Quantity = item.Quantity,
                Price = item.Price
            }).ToList();

            // Gọi hàm trong BAL
            bool result = dbo.CreateFullOrder(ref err, customerID, employeeID, orderDate, totalAmount, paymentMethod, shippingAddress, orderDetails, ref newOrderID);

            if (result)
            {
                MessageBox.Show($"Đặt hàng thành công! Mã đơn hàng: {newOrderID}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OrderPlacedSuccessfully = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đặt hàng thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomerList()
        {
            DataSet ds = dbc.GetCustomers();
            if (ds != null && ds.Tables.Count > 0)
            {
                cbCustomerID.DataSource = ds.Tables[0];
                cbCustomerID.DisplayMember = "FullName";  // Cột bạn muốn hiển thị
                cbCustomerID.ValueMember = "CustomerID";      // Cột dùng để lấy ID
                cbCustomerID.SelectedIndex = -1; // Đặt ban đầu là chưa chọn
            }
            else
            {
                MessageBox.Show("Không thể tải danh sách khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentMethods()
        {
            cbPayment.Items.Add("Tiền mặt");
            cbPayment.Items.Add("Chuyển khoản");
            cbPayment.Items.Add("Thẻ tín dụng");
            cbPayment.SelectedIndex = 0; // Chọn mặc định
        }

        private void cbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
