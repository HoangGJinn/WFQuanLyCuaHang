using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BusinessLogicLayer;
using System.Linq.Expressions;
namespace WFQuanLyCuaHang.Forms
{
    public partial class FormWarranty : Form
    {
        private DAL db;
        private DataTable dtWarranty;
        private bool isLoaded = false;

        public FormWarranty()
        {
            InitializeComponent();
            db = DALManager.Instance;


        }
        void LoadData()
        {
            try
            {
                // Gọi hàm từ DAL để lấy dữ liệu bảo hành
                dtWarranty = db.ExecuteQueryDataTable("SELECT * FROM Warranty", CommandType.Text);

                if (dtWarranty == null || dtWarranty.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xóa cột cũ (nếu có) để tránh trùng
                dgvWarranty.Columns.Clear();

                // Tự tạo cột theo dữ liệu
                dgvWarranty.AutoGenerateColumns = true;

                // Gán dữ liệu vào DataGridView
                dgvWarranty.DataSource = dtWarranty;

                // Reset các trường nhập liệu
                txtWarrantyID.ResetText();
                txtProductID.ResetText();
                txtCustomerID.ResetText();
                txtStartDate.ResetText();
                txtWarrantyCenter.ResetText();
                txtEndDate.ResetText();
                cbExtended.SelectedIndex = 0;

                // Gán lại sự kiện CellClick (tránh gán trùng)
                dgvWarranty.CellClick -= dgvWarranty_CellContentClick;
                dgvWarranty.CellClick += dgvWarranty_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu:\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWarranty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvWarranty.Rows[e.RowIndex].Cells["WarrantyID"].Value != null)
            {
                DataGridViewRow row = dgvWarranty.Rows[e.RowIndex];
                //Gán dữ liệu cho các dòng được chọn
                txtWarrantyID.Text = row.Cells["WarrantyID"].Value.ToString();
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                if (row.Cells["WarrantyCenter"] != null)
                    txtWarrantyCenter.Text = row.Cells["WarrantyCenter"].Value.ToString();
                // Xử lí định dạng ngày
                DateTime StartDate;
                if (DateTime.TryParse(row.Cells["StartDate"].Value.ToString(), out StartDate))
                    txtStartDate.Text = StartDate.ToString("M-dd-yyyy");
                else
                    txtStartDate.Text = "";

                DateTime EndDate;
                if (DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out EndDate))
                    txtEndDate.Text = EndDate.ToString("M-dd-yyyy");
                else
                    txtEndDate.Text = "";
            }
        }
        private void FormWarranty_Load(object sender, EventArgs e)
        {
            dgvWarranty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWarranty.MultiSelect = false; // Không cho chọn nhiều dòng khi gia hạn bảo hành

            cbExtended.Items.Add("3 tháng");
            cbExtended.Items.Add("6 tháng");
            cbExtended.Items.Add("12 tháng");
            LoadData();
            isLoaded = true; // Bây giờ mới cho phép xử lý sự kiện
        }

        private void btnExtendedWarranty_Click(object sender, EventArgs e)
        {
            if (dgvWarranty.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng để gia hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbExtended.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn gói gia hạn bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int monthsToExtend = 0;

            // Xác định số tháng từ nội dung chọn
            switch (cbExtended.SelectedItem.ToString())
            {
                case "3 tháng":
                    monthsToExtend = 3;
                    break;
                case "6 tháng":
                    monthsToExtend = 6;
                    break;
                case "12 tháng":
                    monthsToExtend = 12;
                    break;
                default:
                    MessageBox.Show("Gói gia hạn không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            try
            {
                int warrantyID = Convert.ToInt32(dgvWarranty.CurrentRow.Cells["WarrantyID"].Value);
                DateTime oldDate = Convert.ToDateTime(dgvWarranty.CurrentRow.Cells["EndDate"].Value);
                DateTime newEndDate = oldDate.AddMonths(monthsToExtend);

                string err = string.Empty;
                var dbWarranty = new DBWarranty();
                bool result = dbWarranty.ExtendWarranty(ref err, warrantyID, newEndDate);

                if (result)
                {
                    MessageBox.Show($"Đã gia hạn {monthsToExtend} tháng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Làm mới dữ liệu để thấy kết quả
                }
                else
                {
                    MessageBox.Show("Gia hạn thất bại.\nLỗi: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gia hạn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cbExtended_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded)
                return;
            DateTime startDate;

            // Định dạng tháng/ngày/năm (ví dụ: 4/18/2025)
            if (DateTime.TryParseExact(txtStartDate.Text, "M-d-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                DateTime newEndDate = startDate;

                switch (cbExtended.SelectedItem.ToString())
                {
                    case "3 tháng":
                        newEndDate = startDate.AddMonths(3);
                        break;
                    case "6 tháng":
                        newEndDate = startDate.AddMonths(6);
                        break;
                    case "12 tháng":
                        newEndDate = startDate.AddMonths(12);
                        break;
                }

                txtEndDate.Text = newEndDate.ToString("M-d-yyyy");
            }
            else
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ. Vui lòng nhập theo định dạng tháng/ngày/năm (M-d-yyyy).",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
