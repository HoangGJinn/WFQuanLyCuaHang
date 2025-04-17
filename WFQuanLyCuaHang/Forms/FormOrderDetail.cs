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
using System.Data.SqlClient;
using BusinessLogicLayer;
using System.Diagnostics;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormOrderDetail : Form
    {
        DBOrderDetail dbod;
        DBProduct dbp;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtOrderDetail = null;
        private bool isAdding = false;
        private bool isEditing = false;


        bool Them;
        private int orderID;


        public FormOrderDetail(int orderID)
        {
            InitializeComponent();
            dbod = new DBOrderDetail();
            dbp = new DBProduct();
            this.orderID = orderID;
            this.Load += new EventHandler(FormOrdersDetail_Load);
        }


        private void Resetvalues() // Reset giá trị cho các mục
        {
            txtMaDonhang.ResetText();
            txtMaNhanvien.ResetText();
            txtTenNV.ResetText();
            txtMaKhachhang.ResetText();
            txtTenKhachhang.ResetText();
            MTCustomerN.ResetText();
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtSoluong.ResetText();
            txtStatus.ResetText();
            txtGiaSP.ResetText();

            btnSua.Enabled = true;
            btnQuaylai.Enabled = true;
            btnLuu.Enabled = false;
            btnHuybo.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;

            txtMaKhachhang.Enabled = false;
            txtMaNhanvien.Enabled = false;
            txtMaDonhang.Enabled = false;
            txtTenNV.Enabled = false;
            txtTenKhachhang.Enabled = false;
            MTCustomerN.Enabled = false;
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            txtSoluong.Enabled = false;
            txtStatus.Enabled = false;
            txtGiaSP.Enabled = false;

        }
        private void LoadData(int OrderID)
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtOrderDetail = new DataTable();
                dtOrderDetail.Clear();
                dtOrderDetail = dbod.GetOrderInfo(OrderID).Tables[0];
                dgvDetail.DataSource = dtOrderDetail;

                Resetvalues();
                dgvDetail.CellClick += new DataGridViewCellEventHandler(dgvDetail_CellClick);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }
        private void FormOrdersDetail_Load(object sender, EventArgs e)
        {
            LoadData(orderID);
            dgvDetail.DefaultCellStyle.Font = new Font("Cambria", 10); // Cỡ chữ 10
            dgvDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 11, FontStyle.Bold); // Cỡ chữ tiêu đề lớn hơn
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiaChiKhach_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cho thao tác trên các nút Xem Detail / Xoa 
            this.btnXoa.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            int r = dgvDetail.CurrentCell.RowIndex;

            txtMaDonhang.Text = dgvDetail.Rows[r].Cells["OrderID"].Value?.ToString() ?? "";
            txtMaNhanvien.Text = dgvDetail.Rows[r].Cells["EmployeeID"].Value?.ToString() ?? "";
            txtTenNV.Text = dgvDetail.Rows[r].Cells["EmployeeName"].Value?.ToString() ?? "";
            txtMaKhachhang.Text = dgvDetail.Rows[r].Cells["CustomerID"].Value?.ToString() ?? "";
            txtTenKhachhang.Text = dgvDetail.Rows[r].Cells["CustomerName"].Value?.ToString() ?? "";
            MTCustomerN.Text = dgvDetail.Rows[r].Cells["CustomerPhone"].Value?.ToString() ?? "";
            txtMaSP.Text = dgvDetail.Rows[r].Cells["ProductID"].Value?.ToString() ?? "";
            txtSoluong.Text = dgvDetail.Rows[r].Cells["Quantity"].Value?.ToString() ?? "";
            txtTenSP.Text = dgvDetail.Rows[r].Cells["NameProduct"].Value?.ToString() ?? "";
            txtGiaSP.Text = dgvDetail.Rows[r].Cells["Price"].Value?.ToString() ?? "";
            txtStatus.Text = dgvDetail.Rows[r].Cells["Status"].Value?.ToString() ?? "";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = ""; // Biến lưu lỗi

            if (!int.TryParse(txtMaSP.Text.Trim(), out int productID))
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenSP = dbp.GetProductNameByID(productID);
            if (!string.IsNullOrEmpty(txtTenSP.Text))
            {
                txtTenSP.Text = tenSP;
            }

            if (string.IsNullOrWhiteSpace(txtGiaSP.Text))
            {
                decimal giaSP = dbp.GetProductPriceByID(productID);
                if (giaSP > 0)
                {
                    txtGiaSP.Text = giaSP.ToString();
                }
            }

            int ProductID = productID;
            int Quantity = int.Parse(txtSoluong.Text);
            decimal Price = decimal.Parse(txtGiaSP.Text);
            if (Them)  // Nếu là thêm mới sản phẩm
            {
                try
                {
                    bool result = dbod.AddOrderDetail(ref err, orderID, ProductID, Quantity, Price);
                    if (result)
                    {
                        LoadData(orderID);  // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể thêm. Lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Nếu là cập nhật sản phẩm
            {
                try
                {

                    bool result = dbod.UpdateOrderDetail(ref err, orderID, ProductID, Quantity, Price);
                    if (result)
                    {
                        LoadData(orderID);  // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật. Lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            Resetvalues();
            dgvDetail.CellClick += new DataGridViewCellEventHandler(dgvDetail_CellClick);
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;
            Resetvalues();
            txtGiaSP.ResetText();
            txtMaSP.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiaSP.Enabled = true;
            btnLuu.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;
            //this.pnOD.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            // Đưa con trỏ đến TextFiled txtMaSP
            this.txtMaSP.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvDetail.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                int ProductID = int.Parse(txtMaSP.Text.Trim());

                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có chọn nút OK không?
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lên SQL
                    bool f = dbod.DeleteOrderDetail(ref err, orderID, ProductID);
                    if (f)
                    {
                        // Cập nhật lại DataGridView
                        LoadData(orderID);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;
            txtMaSP.Enabled = true;
            txtSoluong.Enabled = true;
            txtGiaSP.Enabled = true;
            btnLuu.Enabled = true;

            // Cho thao tác trên Panel
            //this.pnOD.Enabled = true;
            dgvDetail.CellClick += new DataGridViewCellEventHandler(dgvDetail_CellClick);

            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuybo.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtMaSP.Focus();
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnOD_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void txtMaDonhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void txtTenKhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNhanvien_TextChanged(object sender, EventArgs e)
        {

        }

        private void MTCustomerN_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btn_autotongtien_CTDH_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_them_CTDH_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormOrderDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
