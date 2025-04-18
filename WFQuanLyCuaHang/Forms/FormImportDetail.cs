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
    public partial class FormImportDetail : Form
    {
        DBImportDetail dbid;
        DBProduct dbp;
        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtOrderDetail = null;
        private bool isAdding = false;
        private bool isEditing = false;

        // Đối tượng đưa dữ liệu vào DataTable dtCustomer
        DataTable dtImportDetail = null;

        bool Them;
        private int ImportDetailID;

        public FormImportDetail(int ImportDetailID)
        {
            InitializeComponent();
            dbid = new DBImportDetail();
            dbp = new DBProduct();
            this.ImportDetailID = ImportDetailID;
            this.Load += new EventHandler(FormImportDetail_Load);
        }
        void LoadData()
        {
            try
            {
                // Vận chuyển dữ liệu vào DataTable
                dtImportDetail = new DataTable();
                dtImportDetail.Clear();
                dtImportDetail = dbid.GetImportDetailsByImportID(ImportDetailID).Tables[0];
                dgvImportDetail.DataSource = dtImportDetail;

                // Xóa trống các đối tượng trong Panel
                this.txtImportID.ResetText();
                this.txtSupplierID.ResetText();
                this.txtProductID.ResetText();
                this.txtImportDate.ResetText();
                this.txtPrice.ResetText();
                this.txtQuantity.ResetText();

                //Không cho thao tác trên nút UpdateStatus / Panel / Xoa / ShowDetail / SaveStatus
                this.pnlOrder.Enabled = false;
                this.btnUpdate.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnHuy.Enabled = false;

                // Cho thao tác trên các nút Thêm / Thoat
                this.btnThem.Enabled = true;
                this.btnHuy.Enabled = true;
                dgvImportDetail.CellClick += new DataGridViewCellEventHandler(dgvImportDetail_CellClick);
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Không lấy được nội dung trong table Customer. Lỗi rồi!!!");
                //MessageBox.Show("Lỗi SQL: " + ex.Message);
                MessageBox.Show("Lỗi khi tải dữ liệu nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void FormImportDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kích hoạt trạng thái thêm mới
            Them = true;

            // Xóa trống các TextBox liên quan đến chi tiết nhập hàng
            this.txtImportID.ResetText();       // Có thể giữ nguyên nếu đang hiển thị ImportID sẵn
            this.txtProductID.ResetText();
            this.txtQuantity.ResetText();
            this.txtPrice.ResetText();

            // Kích hoạt panel nhập liệu và các nút thao tác
            this.pnlOrder.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnHuy.Enabled = true;

            // Vô hiệu hóa các nút không cần dùng lúc thêm
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnUpdate.Enabled = false;

            // Focus vào textbox đầu tiên
            this.txtProductID.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy chỉ số dòng đang chọn
                int r = dgvImportDetail.CurrentCell.RowIndex;

                // Lấy ImportID và ProductID từ textbox (Khóa chính của ImportDetail)
                int importID = int.Parse(txtImportID.Text.Trim());
                int productID = int.Parse(txtProductID.Text.Trim());

                // Hỏi xác nhận
                DialogResult traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết nhập này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                string err = "";

                if (traloi == DialogResult.Yes)
                {
                    // Gọi hàm xóa từ BLL
                    bool success = dbid.DeleteImportDetail(ref err, importID, productID);

                    if (success)
                    {
                        LoadData(); // Load lại danh sách chi tiết nhập hàng
                        MessageBox.Show("Đã xóa chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Đã hủy thao tác xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi xóa chi tiết nhập!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác xóa!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvImportDetail.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn một chi tiết nhập hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kích hoạt chế độ chỉnh sửa
            Them = false;

            // Lấy dòng được chọn và gán dữ liệu lên các textbox
            DataGridViewRow row = dgvImportDetail.SelectedRows[0];
            txtImportID.Text = row.Cells["ImportID"].Value?.ToString() ?? "";
            txtProductID.Text = row.Cells["ProductID"].Value?.ToString() ?? "";
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
            txtImportDate.Text = row.Cells["ImportDate"].Value?.ToString() ?? "";

            // Kích hoạt panel nhập liệu và các nút thao tác
            this.pnlOrder.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnHuy.Enabled = true;

            // Vô hiệu hóa nút Thêm và Xóa khi đang sửa
            this.btnThem.Enabled = false;
            this.btnXoa.Enabled = false;

            // Focus vào textbox đầu tiên để người dùng có thể sửa
            this.txtProductID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";

            // Kiểm tra dữ liệu nhập vào có hợp lệ không
            if (
                string.IsNullOrWhiteSpace(txtImportID.Text) ||
                string.IsNullOrWhiteSpace(txtProductID.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Điền đầy đủ thông tin đi bạn eyyy!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int importID = int.Parse(txtImportID.Text);
                int productID = int.Parse(txtProductID.Text);
                int quantity = int.Parse(txtQuantity.Text);
                decimal price = decimal.Parse(txtPrice.Text);

                if (Them)
                {
                    // Gọi hàm thêm mới chi tiết phiếu nhập
                    bool result = dbid.AddImportDetail(ref err, importID, productID, quantity, price);

                    if (result)
                    {
                        LoadData(); // Load lại dữ liệu lên DataGridView
                        MessageBox.Show("Thêm chi tiết nhập hàng thành công rồi đó bạn!", "Yeahh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại rồi bạn eyy!\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Trường hợp sửa: Nếu bạn có chức năng sửa thì viết thêm ở đây
                    MessageBox.Show("Hiện tại chỉ đang làm chức năng Thêm. Nếu muốn sửa thì mình code tiếp nha!", "Thông báo");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập đúng định dạng số đi bạn eyy!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL rồi bạn ơi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Xóa trống các textbox trong panel chi tiết nhập
            this.txtImportID.ResetText();
            this.txtSupplierID.ResetText();
            this.txtProductID.ResetText();
            this.txtImportDate.ResetText();
            this.txtPrice.ResetText();
            this.txtQuantity.ResetText();

            // Không cho thao tác trên Panel và các nút chức năng
            this.pnlOrder.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnHuy.Enabled = false;

            // Cho phép Thêm
            this.btnThem.Enabled = true;
            this.btnHuy.Enabled = true;

            // Gắn lại sự kiện CellClick nếu đã bị tắt trước đó
            dgvImportDetail.CellClick += new DataGridViewCellEventHandler(dgvImportDetail_CellClick);
        }

        private void dgvImportDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu click vào header hoặc ngoài phạm vi thì bỏ qua
            if (e.RowIndex < 0 || e.RowIndex >= dgvImportDetail.Rows.Count)
                return;

            // Cho phép các nút thao tác (tuỳ bạn thêm nút nào thì bật tương ứng)
            this.btnXoa.Enabled = true;
            this.btnThem.Enabled = false;

            // Lấy dòng đang chọn
            DataGridViewRow row = dgvImportDetail.Rows[e.RowIndex];

            // Gán dữ liệu từ dòng được chọn lên các textbox
            txtImportID.Text = row.Cells["ImportID"].Value?.ToString() ?? "";
            txtImportID.Text = row.Cells["ImportID"].Value?.ToString() ?? "";
            txtProductID.Text = row.Cells["ProductID"].Value?.ToString() ?? "";
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
            txtImportDate.Text = row.Cells["ImportDate"].Value?.ToString() ?? "";
        }
    }
}
