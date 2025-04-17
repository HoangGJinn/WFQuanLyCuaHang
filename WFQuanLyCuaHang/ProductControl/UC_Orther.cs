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
    public partial class UC_Orther : UserControl
    {
        DBProduct dbp;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtProduct = null;
        bool Them;


        public UC_Orther()
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
                dtProduct = dbp.GetProductsExceptLaptop().Tables[0];
                dgvLinhKien.DataSource = dtProduct;

                // Xóa trống các đối tượng trong Panel
                this.txtIDSP.ResetText();
                this.txtTenSP.ResetText();
                this.txtHangSP.ResetText();
                this.txtGiaSP.ResetText();
                this.txtThoigianbaohanh.ResetText();
                this.txtIDSupplier.ResetText();
                this.txtDescription.ResetText();
                this.txtLoaiSP.ResetText();


                // Không cho thao tác trên nút Hủy / Panel
                this.btnHuySP.Enabled = false;
                this.btnLuuSP.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa 
                this.btnThemSP.Enabled = true;
                this.btnSuaSP.Enabled = true;
                this.btnXoaSP.Enabled = true;
                dgvLinhKien.CellClick += new DataGridViewCellEventHandler(dgvLinhKien_CellClick);

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được sản phẩm trong table Product. Lỗi rồi!!!");
            }
        }
        private void UC_Orther_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label_tendienthoai_dienthoai_Click(object sender, EventArgs e)
        {

        }

        private void dgvLinhKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào header hoặc index không hợp lệ
            if (e.RowIndex < 0 || dgvLinhKien.Rows[e.RowIndex].Cells[0].Value == null)
                return;

            this.btnLuuSP.Enabled = false;
            this.btnHuySP.Enabled = true;
            this.btnThemSP.Enabled = false;

            txtIDSP.Text = dgvLinhKien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtIDSupplier.Text = dgvLinhKien.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? "";
            txtTenSP.Text = dgvLinhKien.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? "";
            txtLoaiSP.Text = dgvLinhKien.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? "";
            txtHangSP.Text = dgvLinhKien.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? "";
            txtGiaSP.Text = dgvLinhKien.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? "";
            txtThoigianbaohanh.Text = dgvLinhKien.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? "";
            txtDescription.Text = dgvLinhKien.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? "";
        }



        private void btnHuySP_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtIDSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtHangSP.ResetText();
            this.txtGiaSP.ResetText();
            this.txtThoigianbaohanh.ResetText();
            this.txtIDSupplier.ResetText();
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
            dgvLinhKien.CellClick += new DataGridViewCellEventHandler(dgvLinhKien_CellClick);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtIDSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtHangSP.ResetText();
            this.txtGiaSP.ResetText();
            this.txtThoigianbaohanh.ResetText();
            this.txtIDSupplier.ResetText();
            this.txtDescription.ResetText();
            this.txtLoaiSP.ResetText();
            // Không cho thao tác trên nút Hủy / Panel /Lưu
            this.btnHuySP.Enabled = false;
            this.pnListLap.Enabled = false;
            this.btnLuuSP.Enabled = false;


            // Cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThemSP.Enabled = true;
            this.btnSuaSP.Enabled = true;
            this.btnXoaSP.Enabled = true;
            // Đưa con trỏ đến TextFiled txtTenLap
            this.txtTenSP.Focus();
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
            this.pnListLap.Enabled = true;
            dgvLinhKien.CellClick += new DataGridViewCellEventHandler(dgvLinhKien_CellClick);

            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuuSP.Enabled = true;
            this.btnHuySP.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThemSP.Enabled = false;
            this.btnSuaSP.Enabled = false;
            this.btnXoaSP.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaDV
            this.txtTenSP.Focus();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành
                int r = dgvLinhKien.CurrentCell.RowIndex;
                // Lấy MaDV của record hiện hành
                int strMaSP = Convert.ToInt32(dgvLinhKien.Rows[r].Cells[0].Value);

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
            if (!int.TryParse(txtIDSupplier.Text.Trim(), out int supplierID) || supplierID <= 0)
            {
                err = "Mã nhà cung cấp phải là số nguyên dương!";
                return false;
            }

            // Kiểm tra NameProduct (không được rỗng)
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
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
            if (string.IsNullOrWhiteSpace(txtHangSP.Text))
            {
                err = "Thương hiệu không được để trống!";
                return false;
            }

            // Kiểm tra Price (phải là số thực >= 0)
            if (!decimal.TryParse(txtGiaSP.Text.Trim(), out decimal price) || price < 0)
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
            int supplierID = int.Parse(txtIDSupplier.Text.Trim());
            decimal price = decimal.Parse(txtGiaSP.Text.Trim());
            int warranty = int.Parse(txtThoigianbaohanh.Text.Trim());

            if (Them)  // Nếu là thêm mới sản phẩm
            {
                try
                {
                    bool result = dbp.AddProduct(ref err, supplierID, txtTenSP.Text, txtLoaiSP.Text,
                                                       txtHangSP.Text, price, warranty, txtDescription.Text);
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
                    int productID = int.Parse(txtIDSP.Text.Trim()); // Ép kiểu ProductID

                    bool result = dbp.UpdateProduct(ref err, supplierID, productID, txtTenSP.Text, txtLoaiSP.Text,
                                                          txtHangSP.Text, price, warranty, txtDescription.Text);
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

        private void dgvLaptop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGiaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLinhKien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFindPhukien_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTenSP.Text.Trim();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Vui lòng nhập phụ kiện cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = dbp.SearchNonLaptopByName(keyword);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvLinhKien.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phụ kiện nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phụ kiện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
