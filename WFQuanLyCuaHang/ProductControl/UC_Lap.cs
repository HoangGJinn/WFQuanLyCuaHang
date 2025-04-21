using BusinessLogicLayer;
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

namespace WFQuanLyCuaHang.ProductControl
{
    public partial class UC_Lap : UserControl
    {
        DBProduct dbp;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtProduct = null;
        bool Them;

        public UC_Lap()
        {
            InitializeComponent();
            dbp = new DBProduct();
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbp.GetLaptops().Tables[0];
                dgvLap.DataSource = dtProduct;

                // Xóa trống các đối tượng trong Panel
                this.txtIDSupplier.ResetText();
                this.txtTenLap.ResetText();
                this.txtHangLap.ResetText();
                this.txtGia.ResetText();
                this.txtThoigianbaohanh.ResetText();
                this.txtIDLap.ResetText();
                this.txtDescription.ResetText();
                this.txtLoaiSP.ResetText();

                // Không cho thao tác trên nút Hủy / Panel /Lưu
                this.btnHuySP.Enabled = false;
                this.btnLuuSP.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa 
                this.btnThemSP.Enabled = true;
                this.btnSuaSP.Enabled = true;
                this.btnXoaSP.Enabled = true;
                dgvLap.CellClick += new DataGridViewCellEventHandler(dgvLap_CellClick);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được sản phẩm trong table Product. Lỗi rồi!!!");
            }
        }

        private void UC_Lap_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvLap.CellClick += new DataGridViewCellEventHandler(dgvLap_CellClick);
        }

        private void panel_DienThoai_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvLap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào header hoặc vị trí không hợp lệ → bỏ qua
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Nếu là dòng trống (dòng để thêm mới), bỏ qua luôn
            if (dgvLap.Rows[e.RowIndex].IsNewRow)
                return;

            // Sau đó mới xử lý
            DataGridViewRow row = dgvLap.Rows[e.RowIndex];

            this.btnLuuSP.Enabled = false;
            this.btnHuySP.Enabled = true;
            this.btnThemSP.Enabled = false;

            // Lấy index dòng được chọn
            int r = e.RowIndex;

            // Kiểm tra dữ liệu hợp lệ
            if (dgvLap.Rows[r].Cells[0].Value != null)
            {
                txtIDSupplier.Text = dgvLap.Rows[r].Cells[0].Value?.ToString() ?? "";
                txtIDLap.Text = dgvLap.Rows[r].Cells[1].Value?.ToString() ?? "";
                txtTenLap.Text = dgvLap.Rows[r].Cells[2].Value?.ToString() ?? "";
                txtLoaiSP.Text = dgvLap.Rows[r].Cells[3].Value?.ToString() ?? "";
                txtHangLap.Text = dgvLap.Rows[r].Cells[4].Value?.ToString() ?? "";
                txtGia.Text = dgvLap.Rows[r].Cells[5].Value?.ToString() ?? "";
                txtThoigianbaohanh.Text = dgvLap.Rows[r].Cells[6].Value?.ToString() ?? "";
                txtDescription.Text = dgvLap.Rows[r].Cells[7].Value?.ToString() ?? "";
            }
        }

        private void label_soluong_dienthoai_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtIDSupplier.ResetText();
            this.txtTenLap.ResetText();
            this.txtHangLap.ResetText();
            this.txtGia.ResetText();
            this.txtThoigianbaohanh.ResetText();
            this.txtIDLap.ResetText();
            this.txtDescription.ResetText();
            this.txtLoaiSP.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuSP.Enabled = false;
            this.btnHuySP.Enabled = false;
            this.pnListLap.Enabled = false;

            // Cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThemSP.Enabled = true;
            this.btnSuaSP.Enabled = true;
            this.btnXoaSP.Enabled = true;
            dgvLap.CellClick += new DataGridViewCellEventHandler(dgvLap_CellClick);
        }

        private void btnThemSanpham_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtIDSupplier.ResetText();
            this.txtTenLap.ResetText();
            this.txtHangLap.ResetText();
            this.txtGia.ResetText();
            this.txtThoigianbaohanh.ResetText();
            this.txtIDLap.ResetText();
            this.txtDescription.ResetText();
            this.txtLoaiSP.ResetText();
            this.txtThoigianbaohanh.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuuSP.Enabled = true;
            this.btnHuySP.Enabled = true;
            this.pnListLap.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Sửa / Xóa
            this.btnThemSP.Enabled = false;
            this.btnSuaSP.Enabled = false;
            this.btnXoaSP.Enabled = false;
            // Đưa con trỏ đến TextFiled txtTenLap
            this.txtTenLap.Focus();

        }

        private void btnRLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;

            // Cho thao tác trên Panel
            dgvLap.CellClick += new DataGridViewCellEventHandler(dgvLap_CellClick);

            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuuSP.Enabled = true;
            this.btnHuySP.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThemSP.Enabled = false;
            this.btnSuaSP.Enabled = false;
            this.btnXoaSP.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaDV
            this.txtTenLap.Focus();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dgvLap.CurrentCell.RowIndex;
                // Lấy MaDV của record hiện hành
                int strMaSP = Convert.ToInt32(dgvLap.Rows[r].Cells[0].Value);

                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có chọn nút OK không?
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lên SQL
                    bool f = dbp.DeleteProduct(ref err, strMaSP);
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

        private bool CheckProductData(out string err)
        {
            err = ""; // Mặc định không có lỗi

            // Kiểm tra SupplierID (phải là số nguyên dương)
            if (!int.TryParse(txtIDLap.Text.Trim(), out int supplierID) || supplierID <= 0)
            {
                err = "Mã nhà cung cấp phải là số nguyên dương!";
                return false;
            }

            // Kiểm tra NameProduct (không được rỗng)
            if (string.IsNullOrWhiteSpace(txtTenLap.Text))
            {
                err = "Tên sản phẩm không được để trống!";
                return false;
            }

            // Kiểm tra Category (không được rỗng)
            if (string.IsNullOrWhiteSpace(txtLoaiSP.Text))
            {
                err = "Danh mục sản phẩm không được để trống!";
                return false;
            }

            // Kiểm tra Brand (không được rỗng)
            if (string.IsNullOrWhiteSpace(txtHangLap.Text))
            {
                err = "Thương hiệu không được để trống!";
                return false;
            }

            // Kiểm tra Price (phải là số thực >= 0)
            if (!decimal.TryParse(txtGia.Text.Trim(), out decimal price) || price < 0)
            {
                err = "Giá sản phẩm phải là số thực không âm!";
                return false;
            }

            // Kiểm tra WarrantyPeriod (phải là số nguyên không âm)
            if (!int.TryParse(txtThoigianbaohanh.Text.Trim(), out int warranty) || warranty < 0)
            {
                err = "Thời gian bảo hành phải là số nguyên không âm!";
                return false;
            }

            // Kiểm tra Description (không được rỗng)
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                err = "Mô tả sản phẩm không được để trống!";
                return false;
            }

            return true; // Dữ liệu hợp lệ
        }
        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            string err = ""; // Biến lưu lỗi

            // Kiểm tra dữ liệu trước khi lưu
            if (!CheckProductData(out err))
            {
                MessageBox.Show("Lỗi: " + err, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ép kiểu các giá trị cần thiết
            int supplierID = int.Parse(txtIDLap.Text.Trim());
            decimal price = decimal.Parse(txtGia.Text.Trim());
            int warranty = int.Parse(txtThoigianbaohanh.Text.Trim());

            if (Them)  // Nếu là thêm mới sản phẩm
            {
                try
                {
                    bool result = dbp.AddProduct(ref err, supplierID, txtTenLap.Text, txtLoaiSP.Text,
                                                       txtHangLap.Text, price, warranty, txtDescription.Text);
                    if (result)
                    {
                        LoadData();  // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể thêm sản phẩm. Lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Nếu là cập nhật sản phẩm
            {
                try
                {
                    int productID = int.Parse(txtIDSupplier.Text.Trim()); // Ép kiểu ProductID

                    bool result = dbp.UpdateProduct(ref err, supplierID, productID, txtTenLap.Text, txtLoaiSP.Text,
                                                          txtHangLap.Text, price, warranty, txtDescription.Text);
                    if (result)
                    {
                        LoadData();  // Load lại dữ liệu trên DataGridView
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thể cập nhật sản phẩm. Lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_madienthoai_dienthoai_Click(object sender, EventArgs e)
        {

        }

        private void txtIDLap_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLap_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnFindLap_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTenLap.Text.Trim();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên Laptop cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = dbp.SearchLaptopByName(keyword);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvLap.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Laptop nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm Laptop: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
