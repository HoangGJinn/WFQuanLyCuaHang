using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
//
using System.Data.SqlClient;
using BusinessLogicLayer;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormOrders: Form
    {
        DBOrder dbo;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtOrder = null;

        bool Them;
        public FormOrders()
        {
            InitializeComponent();
            dbo = new DBOrder();
            // Ví dụ này dùng danh sách tĩnh
            var statuses = new List<string> { "Chờ xử lý", "Đang giao", "Đã giao", "Đã hủy" };
            cboStatus.DataSource = statuses;
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtOrder = new DataTable();
                dtOrder.Clear();
                dtOrder = dbo.GetOrders().Tables[0];
                dgvOrder.DataSource = dtOrder;

                // Xóa trống các đối tượng trong Panel
                this.txtOrderID.ResetText();
                this.txtCustomerID.ResetText();
                this.txtEmployeeID.ResetText();
                cboStatus.Enabled = false;
                cboStatus.SelectedIndex = -1;
                this.txtAddr.ResetText();
                this.txtTotal.ResetText();
                this.txtDate.ResetText();
                this.txtPayMethod.ResetText();

                //Không cho thao tác trên nút UpdateStatus / Panel / Xoa / ShowDetail / SaveStatus
                this.pnlOrder.Enabled = false;
                this.btnUpdateStatus.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnShowDetail.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnHuy.Enabled = false;

                // Cho thao tác trên các nút Thêm / Thoat
                this.btnThem.Enabled = true;
                this.btnHuy.Enabled = true;
                dgvOrder.CellClick += new DataGridViewCellEventHandler(dgvOrder_CellClick);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                //MessageBox.Show("Lỗi SQL: " + ex.Message);
                MessageBox.Show("Lỗi khi tải dữ liệu đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cho thao tác trên các nút Xem Detail / Xoa 
            this.btnShowDetail.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnUpdateStatus.Enabled = true;
            this.btnThem.Enabled = false;


            int r = dgvOrder.CurrentCell.RowIndex;

            txtOrderID.Text = dgvOrder.Rows[r].Cells[0].Value?.ToString() ?? "";
            txtCustomerID.Text = dgvOrder.Rows[r].Cells[1].Value?.ToString() ?? "";
            txtEmployeeID.Text = dgvOrder.Rows[r].Cells[2].Value?.ToString() ?? "";
            // Kiểm tra và chuyển đổi Ngay Dat Hang
            var dateValue = dgvOrder.Rows[r].Cells[3].Value;
            if (dateValue != null && DateTime.TryParse(dateValue.ToString(), out DateTime ngayDatHang))
            {
                txtDate.Text = ngayDatHang.ToString("dd/MM/yyyy");
            }
            else
            {
                txtDate.Text = ""; // Nếu NULL hoặc không hợp lệ
            }
            txtTotal.Text = dgvOrder.Rows[r].Cells[4].Value?.ToString() ?? "";

            var statusValue = dgvOrder.Rows[r].Cells[5].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(statusValue))
                cboStatus.SelectedItem = statusValue;
            else
                cboStatus.SelectedIndex = -1;

            txtPayMethod.Text = dgvOrder.Rows[r].Cells[6].Value?.ToString() ?? "";
            txtAddr.Text = dgvOrder.Rows[r].Cells[7].Value?.ToString() ?? "";
        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvOrder.DefaultCellStyle.Font = new Font("Cambria", 10); // Cỡ chữ 10
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 11, FontStyle.Bold); // Cỡ chữ tiêu đề lớn hơn
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvOrder.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                int orderID = int.Parse(txtOrderID.Text.Trim());

                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có chọn nút OK không?
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lên SQL
                    bool f = dbo.DeleteOrder(ref err, orderID);
                    if (f)
                    {
                        // Cập nhật lại DataGridView
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Đã xóa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\n\r" + "Lỗi:" + err);
                    }
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Không thực hiện việc xóa mẫu tin!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;

            // Xóa trống các đối tượng trong Panel
            this.txtCustomerID.ResetText();
            this.txtEmployeeID.ResetText();
            this.txtDate.ResetText();
            this.txtTotal.ResetText();
            this.txtAddr.ResetText();

            cboStatus.SelectedIndex = -1;
            cboStatus.Enabled = true;

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.pnlOrder.Enabled = true;
            this.btnUpdateStatus.Enabled = true;
            this.btnHuy.Enabled = true;
            //this.pnlCustomer.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Xóa
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtCustomerID.Focus();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;

            dgvOrder.CellClick += new DataGridViewCellEventHandler(dgvOrder_CellClick);
            this.pnlOrder.Enabled = true;
            this.btnUpdateStatus.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnHuy.Enabled = true;
            // Disable cac txt ko lien quan
            this.txtAddr.Enabled = false;
            this.txtCustomerID.Enabled = false;
            this.txtDate.Enabled = false;
            this.txtEmployeeID.Enabled = false;
            this.txtOrderID.Enabled = false;
            this.txtPayMethod.Enabled = false;
            this.txtTotal.Enabled = false;
            // Chỉ cho thao tác trên combo trạng thái
            cboStatus.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtOrderID.ResetText();
            this.txtCustomerID.ResetText();
            this.txtEmployeeID.ResetText();
            cboStatus.SelectedIndex = -1;
            cboStatus.Enabled = false;
            this.txtAddr.ResetText();
            this.txtTotal.ResetText();
            this.txtDate.ResetText();
            this.txtPayMethod.ResetText();

            //Không cho thao tác trên nút UpdateStatus / Panel / Xoa / ShowDetail / SaveStatus
            this.pnlOrder.Enabled = false;
            this.btnUpdateStatus.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnShowDetail.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnHuy.Enabled = false;

            // Cho thao tác trên các nút Thêm / Thoat
            this.btnThem.Enabled = true;
            this.btnHuy.Enabled = true;
            dgvOrder.CellClick += new DataGridViewCellEventHandler(dgvOrder_CellClick);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";
            int orderID = int.Parse(txtOrderID.Text);
            int customerID = int.Parse(txtCustomerID.Text);
            int employeeID = int.Parse(txtEmployeeID.Text);
            decimal totalAmount = decimal.Parse(txtTotal.Text);
            string status = cboStatus.SelectedItem.ToString();
            string paymentMethod = txtPayMethod.Text;
            string shippingAddress = txtAddr.Text;

            if (!Them) // Nếu đang Sửa trạng thái
            {
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (cboStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Bạn phải chọn trạng thái!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    // Lệnh Insert Into
                    string newStatus = cboStatus.SelectedItem.ToString();
                    bool f = dbo.UpdateOrderStatus(ref err, orderID, newStatus);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridVew
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã cập nhật xong!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chưa xong!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không cập nhật được. Lỗi rồi!");
                }
            }
            else
            {
                DateTime orderDate = DateTime.Parse(txtDate.Text);
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (
                    string.IsNullOrWhiteSpace(txtCustomerID.Text) ||
                    string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                    string.IsNullOrWhiteSpace(txtDate.Text)       ||
                    string.IsNullOrWhiteSpace(txtTotal.Text)      ||
                    cboStatus.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(txtPayMethod.Text) ||
                    string.IsNullOrWhiteSpace(txtAddr.Text))
                {
                    MessageBox.Show("Nhập đủ thì tôi mới thêm được bạn eyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }

                try
                {
                    // Lệnh Insert Into
                    bool f = dbo.AddOrder(ref err,
                    customerID,
                    employeeID,
                    orderDate,
                    totalAmount,
                    status,
                    paymentMethod,
                    shippingAddress);
                    if (f)
                    {
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo 
                        MessageBox.Show("Thêm rùi nè!");
                    }
                    else
                    {
                        MessageBox.Show("Oh no lỗi rùi!\n\r" + "Lỗi:" + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi");
                }
            }
            
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            // load form chi tiết đơn hàng lên
            int orderID = int.Parse(txtOrderID.Text.Trim());

            FormOrderDetail formOrderDetail = new FormOrderDetail(orderID);
            formOrderDetail.StartPosition = FormStartPosition.CenterParent;
            formOrderDetail.ShowDialog();
        }
    }
}
