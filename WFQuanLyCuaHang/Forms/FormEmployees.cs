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

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormEmployees : Form
    {
        DBEmployee dbe;
        DataTable dtEmployees = null;

        bool Them = false;
        public FormEmployees()
        {
            InitializeComponent();
            dbe = new DBEmployee();
        }

        private void FormEmployees_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                dtEmployees = new DataTable();
                dtEmployees.Clear();
                DataSet ds = dbe.GetEmployees();
                dtEmployees = ds.Tables[0];
                dgvNhanVien.DataSource = dtEmployees;
                dgvNhanVien.Columns["HireDate"].DefaultCellStyle.Format = "MM/dd/yyyy"; // Hoặc "yyyy-MM-dd"

                // Xóa trống các đối tượng trong Panel
                this.txtEmployeeID.ResetText();
                this.txtFullName.ResetText();
                this.txtPhone.ResetText();
                this.txtAddr.ResetText();
                this.txtPos.ResetText();
                this.txtSalary.ResetText();
                this.txtHireDate.ResetText();
                this.txtStatus.ResetText();

                //Không cho thao tác trên nút Hủy / Panel / Sua / Xoa
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.pnlNhanVien.Enabled = false;
                this.btnSua.Enabled = false;
                this.btnXoa.Enabled = false;

                // Cho thao tác trên các nút Thêm / Sửa / Xóa 
                this.btnThem.Enabled = true;
                this.btnThoat.Enabled = true;
                dgvNhanVien.CellClick += new DataGridViewCellEventHandler(dgvNhanVien_CellClick);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvNhanVien.Rows.Count)
                return;

            // Cho thao tac tren cac nut Sua / Xoa
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            int r = dgvNhanVien.CurrentCell.RowIndex;
            this.txtEmployeeID.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            this.txtFullName.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            this.txtPhone.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            this.txtAddr.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            this.txtPos.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            this.txtSalary.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            // Kiểm tra giá trị của ô HireDate trước khi chuyển đổi
            var hireDateValue = dgvNhanVien.Rows[r].Cells[6].Value;
            if (hireDateValue != null && DateTime.TryParse(hireDateValue.ToString(), out DateTime hireDate))
            {
                this.txtHireDate.Text = hireDate.ToString("MM/dd/yyyy");
            }
            else
            {
                this.txtHireDate.Text = ""; // Hoặc có thể hiển thị một thông báo lỗi
            }
            this.txtStatus.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtAddr_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pnlCustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            this.txtEmployeeID.ResetText();
            this.txtFullName.ResetText();
            this.txtPhone.ResetText();
            this.txtAddr.ResetText();
            this.txtPos.ResetText();
            this.txtSalary.ResetText();
            this.txtHireDate.ResetText();
            this.txtStatus.ResetText();

            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlNhanVien.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtEmployeeID.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kích hoạt biến Sửa
            Them = false;

            // Cho thao tác trên Panel
            this.pnlNhanVien.Enabled = true;
            dgvNhanVien.CellClick += new DataGridViewCellEventHandler(dgvNhanVien_CellClick);

            // Cho thao tác trên các nút Lưu / Hủy
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;

            // Không cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;

            // Đưa con trỏ đến TextFiled txtMaKH
            this.txtEmployeeID.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";

            if (Them) // Nếu đang Thêm dữ liệu
            {
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddr.Text) || 
                    string.IsNullOrWhiteSpace(txtPos.Text) || 
                    string.IsNullOrWhiteSpace(txtSalary.Text))
                    //string.IsNullOrWhiteSpace(txtHireDate.Text)
                {
                    MessageBox.Show("Nhập đủ Họ tên, SĐT, Địa Chỉ thì tôi mới thêm được bạn eyy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }

                try
                {
                    // Lệnh Insert Into
                    bool f = dbe.AddEmployee(ref err,
                    this.txtFullName.Text.ToString(),
                    this.txtPhone.Text.ToString(),
                    this.txtAddr.Text.ToString(),
                    this.txtPos.Text.ToString(),
                    decimal.Parse(this.txtSalary.Text.ToString()),
                    DateTime.Parse(this.txtHireDate.Text.ToString()),
                    this.txtStatus.Text.ToString());
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
                    string.IsNullOrWhiteSpace(txtAddr.Text) && string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    MessageBox.Show("Bạn chưa chọn thông tin để sửa áa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }
                // Kiểm tra xem có ô nào bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone.Text) ||
                    string.IsNullOrWhiteSpace(txtAddr.Text) || string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    MessageBox.Show("Đừng để trống bạn eyyyy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có ô trống
                }
                // Ép kiểu txtEmployeeID về int 
                int maNV = int.Parse(txtEmployeeID.Text.Trim());
                try
                {
                    // Lệnh Update
                    bool f = dbe.UpdateEmployee(ref err,
                    maNV,
                    this.txtFullName.Text.ToString(),
                    this.txtPhone.Text.ToString(),
                    this.txtAddr.Text.ToString(),
                    this.txtPos.Text.ToString(),
                    decimal.Parse(this.txtSalary.Text.ToString()),
                    DateTime.Parse(this.txtHireDate.Text.ToString()),
                    this.txtStatus.Text.ToString());
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
            this.txtEmployeeID.ResetText();
            this.txtFullName.ResetText();
            this.txtPhone.ResetText();
            this.txtAddr.ResetText();
            this.txtPos.ResetText();
            this.txtSalary.ResetText();
            this.txtHireDate.ResetText();
            this.txtStatus.ResetText();

            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.pnlNhanVien.Enabled = false;

            // Cho thao tác trên các nút Thêm / Sửa / Xóa 
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            dgvNhanVien.CellClick += new DataGridViewCellEventHandler(dgvNhanVien_CellClick);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thứ tự record hiện hành 
                int r = dgvNhanVien.CurrentCell.RowIndex;
                // Lấy MaNV của record hiện hành
                int maNV = int.Parse(txtEmployeeID.Text.Trim());

                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa mẫu tin này không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có chọn nút OK không?
                string err = "";
                if (traloi == DialogResult.Yes)
                {
                    // Thực hiện câu lên SQL
                    bool f = dbe.DeleteEmployee(ref err, maNV);
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


        private void btnFindNV_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtFullName.Text.Trim();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    MessageBox.Show("Vui lòng nhập tên nhân viên cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = dbe.SearchEmployeeByName(keyword);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dgvNhanVien.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
