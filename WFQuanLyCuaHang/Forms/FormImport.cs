using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLogicLayer;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormImport : Form
    {
        DBImport dbi;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtImport = null;

        bool Them;
        public FormImport()
        {
            InitializeComponent();
            dbi = new DBImport();
            // Ví dụ này dùng danh sách tĩnh
            var statuses = new List<string> { "Chờ xử lý", "Hoàn thành", "Đã hủy" };
            cboStatus.DataSource = statuses;

        }
        public string username { get; private set; }
        public string usertype { get; private set; }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtImport = new DataTable();
                dtImport.Clear();
                dtImport = dbi.GetImports().Tables[0];
                dgvImport.DataSource = dtImport;

                // Xóa trống các đối tượng trong Panel
                this.txtImportID.ResetText();
                this.txtEmployeeID.ResetText();
                this.txtImportDate.ResetText();
                this.txtTotalCost.ResetText();

                cboStatus.Enabled = false;
                cboStatus.SelectedIndex = -1;

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
                dgvImport.CellClick += new DataGridViewCellEventHandler(dgvImport_CellClick);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                //MessageBox.Show("Lỗi SQL: " + ex.Message);
                MessageBox.Show("Lỗi khi tải dữ liệu nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            // load form chi tiết đơn hàng lên
            int ImportID = int.Parse(txtImportID.Text.Trim());

            FormImportDetail formImportDetail = new FormImportDetail(ImportID);
            formImportDetail.StartPosition = FormStartPosition.CenterParent;
            formImportDetail.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.username = username;
            this.usertype = usertype;
            FormAddImport1 formAddImport1 = new FormAddImport1(username, usertype);
            formAddImport1.StartPosition = FormStartPosition.CenterParent;
            formAddImport1.BringToFront();
            formAddImport1.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy chỉ số dòng hiện hành
                int r = dgvImport.CurrentCell.RowIndex;

                // Lấy ImportID từ textbox
                int importID = int.Parse(txtImportID.Text.Trim());

                // Hỏi người dùng có chắc chắn muốn xóa
                DialogResult traloi = MessageBox.Show("Chắc chắn xóa phiếu nhập này không?", "Xác nhận",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                string err = "";

                if (traloi == DialogResult.Yes)
                {
                    // Gọi phương thức xóa trong DBImport
                    bool success = dbi.DeleteImport(ref err, importID);

                    if (success)
                    {
                        // Load lại dữ liệu
                        LoadData();
                        MessageBox.Show("Đã xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hủy thao tác xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa phiếu nhập.\nLỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // Kích hoạt chế độ Sửa
            Them = false;

            dgvImport.CellClick += new DataGridViewCellEventHandler(dgvImport_CellClick);
            this.pnlOrder.Enabled = true;
            this.btnUpdateStatus.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnHuy.Enabled = true;

            // Disable các TextBox không liên quan
            this.txtImportID.Enabled = false;
            this.txtEmployeeID.Enabled = false;
            this.txtImportDate.Enabled = false;
            this.txtTotalCost.Enabled = false;

            // Focus vào txtStatus để cập nhật
            cboStatus.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang ở chế độ cập nhật trạng thái (không phải thêm)
            string Status = cboStatus.SelectedItem.ToString();
            if (!Them)
            {
                // Kiểm tra xem ô trạng thái có bị bỏ trống không
                if (cboStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng nhập trạng thái mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string err = "";
                    int importID = int.Parse(txtImportID.Text);
                    string status = Status;

                    bool f = dbi.UpdateImportStatus(ref err, importID, status);
                    if (f)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật trạng thái thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật trạng thái!\n\rLỗi: " + err);
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi cập nhật trạng thái. Vui lòng kiểm tra kết nối hoặc dữ liệu.");
                }
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtImportID.ResetText();
            this.txtEmployeeID.ResetText();
            cboStatus.SelectedIndex = -1;
            cboStatus.Enabled = false;
            this.txtTotalCost.ResetText();
            this.txtImportDate.ResetText();

            // Không cho thao tác trên nút UpdateStatus / Panel / Xoa / ShowDetail / SaveStatus
            this.pnlOrder.Enabled = false;
            this.btnUpdateStatus.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnShowDetail.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnHuy.Enabled = false;

            // Cho thao tác trên các nút Thêm / Thoát
            this.btnThem.Enabled = true;
            this.btnHuy.Enabled = true;

            // Gắn lại sự kiện CellClick cho dgvImport (thay vì dgvOrder)
            dgvImport.CellClick += new DataGridViewCellEventHandler(dgvImport_CellClick);
        }

        private void dgvImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btnUpdateStatus.Enabled = false;
            if (cboStatus.Text == "Chờ xử lý")
                this.btnUpdateStatus.Enabled = true;
            // Cho phép các nút thao tác
            this.btnShowDetail.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnThem.Enabled = false;

            // Lấy chỉ số dòng đang chọn
            int r = dgvImport.CurrentCell.RowIndex;

            // Gán dữ liệu từ dòng được chọn lên các textbox
            txtImportID.Text = dgvImport.Rows[r].Cells["ImportID"].Value?.ToString() ?? "";
            txtEmployeeID.Text = dgvImport.Rows[r].Cells["EmployeeID"].Value?.ToString() ?? "";

            var importDate = dgvImport.Rows[r].Cells["ImportDate"].Value;
            if (importDate != null && DateTime.TryParse(importDate.ToString(), out DateTime date))
            {
                txtImportDate.Text = date.ToString("dd/MM/yyyy");
            }
            else
            {
                txtImportDate.Text = "";
            }

            txtTotalCost.Text = dgvImport.Rows[r].Cells["TotalCost"].Value?.ToString() ?? "";
            var statusValue = dgvImport.Rows[r].Cells["Status"].Value?.ToString() ?? "";
            if (!string.IsNullOrEmpty(statusValue))
                cboStatus.SelectedItem = statusValue;
            else
                cboStatus.SelectedIndex = -1;
        }

        private void FormImport_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
