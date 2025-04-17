using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Provider
using System.Data.SqlClient;
using BusinessLogicLayer;
using System.Globalization;
using FontAwesome.Sharp;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormCustomers: Form
    {
        DBCustomer dbc;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtCustomer = null;

        bool Them;

        public FormCustomers()
        {
            InitializeComponent();
            dbc = new DBCustomer();
        }

        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtCustomer = new DataTable();
                dtCustomer.Clear();
                dtCustomer = dbc.GetCustomers().Tables[0];
                dgvKhachHang.DataSource = dtCustomer;

                // Xóa trống các đối tượng trong Panel
                this.txtCustomerID.ResetText();
                this.txtFullName.ResetText();
                this.txtPhone.ResetText();
                this.txtAddr.ResetText();

                //Không cho thao tác trên nút Hủy / Panel / Sua / Xoa
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.pnlCustomer.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa 
                this.btnThem.Enabled = true;
                dgvKhachHang.CellClick += new DataGridViewCellEventHandler(dgvKhachHang_CellClick);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cho thao tac tren cac nut Sua / Xoa
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            int r = dgvKhachHang.CurrentCell.RowIndex;

            txtCustomerID.Text = dgvKhachHang.Rows[r].Cells[0].Value?.ToString() ?? "";
            txtFullName.Text = dgvKhachHang.Rows[r].Cells[1].Value?.ToString() ?? "";
            txtPhone.Text = dgvKhachHang.Rows[r].Cells[2].Value?.ToString() ?? "";
            txtAddr.Text = dgvKhachHang.Rows[r].Cells[3].Value?.ToString() ?? "";
        }

        private void FormCustomers_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvKhachHang.DefaultCellStyle.Font = new Font("Cambria", 10); // Cỡ chữ 10
            dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 11, FontStyle.Bold); // Cỡ chữ tiêu đề lớn hơn
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Them
            Them = true;

            // Xóa trống các đối tượng trong Panel
            this.txtCustomerID.ResetText();
            this.txtFullName.ResetText();
            this.txtPhone.ResetText();
            this.txtAddr.ResetText();


            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlCustomer.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtCustomerID.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            // Kích hoạt biến Sửa
            Them = false;

            // Cho thao tác trên Panel
            this.pnlCustomer.Enabled = true;
            dgvKhachHang.CellClick += new DataGridViewCellEventHandler(dgvKhachHang_CellClick);

            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtCustomerID.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";

            if (Them) // Nếu đang Thêm dữ liệu
            {
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddr.Text))
                {
                    MessageBox.Show("Nhập đủ Họ tên, SĐT, Địa Chỉ thì tôi mới thêm được bạn eyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }

                try
                {
                    // Lệnh Insert Into
                    bool f = dbc.AddCustomer(ref err,
                    this.txtFullName.Text.ToString(),
                    this.txtPhone.Text.ToString(),
                    this.txtAddr.Text.ToString());
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
            else // Nếu đang Sửa dữ liệu
            {
                // Kiểm tra nếu chưa chọn để sửa
                if (string.IsNullOrWhiteSpace(txtFullName.Text) &&
                    string.IsNullOrWhiteSpace(txtPhone.Text) &&
                    string.IsNullOrWhiteSpace(txtAddr.Text) && string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Bạn chưa chọn thông tin để sửa áa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddr.Text) || string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Đừng để trống bạn eyyyy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }
                // Ép kiểu txtMaKH về int 
                int maKH = int.Parse(txtCustomerID.Text.Trim());
                try
                {
                    // Lệnh Insert Into
                    bool f = dbc.UpdateCustomer(ref err,
                    maKH,
                    this.txtFullName.Text.ToString(),
                    this.txtPhone.Text.ToString(),
                    this.txtAddr.Text.ToString());
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
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtCustomerID.ResetText();
            this.txtFullName.ResetText();
            this.txtPhone.ResetText();
            this.txtAddr.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.pnlCustomer.Enabled = false;

            // Cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            dgvKhachHang.CellClick += new DataGridViewCellEventHandler(dgvKhachHang_CellClick);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvKhachHang.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                int maKH = int.Parse(txtCustomerID.Text.Trim());

                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có chọn nút OK không?
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lên SQL
                    bool f = dbc.DeleteCustomer(ref err, maKH);
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


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhachHang_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFindKH_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtFullName.Text.Trim();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = dbc.SearchCustomerByName(keyword);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvKhachHang.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFindKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
