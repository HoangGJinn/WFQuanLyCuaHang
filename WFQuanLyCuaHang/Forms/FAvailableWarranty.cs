using BusinessLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FAvailableWarranty : Form
    {
        private DBWarranty DBWarranty;
        private DataSet ds;

        public FAvailableWarranty()
        {
            InitializeComponent();
            DBWarranty = new DBWarranty();
            ds = DBWarranty.GetExpiredWarranties(); // Lấy dữ liệu từ BLL
        }

        private void FAvailableWarranty_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListOfUnavailableWarranty.DataSource = null;
                dgvListOfUnavailableWarranty.Rows.Clear();
                dgvListOfUnavailableWarranty.Columns.Clear();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgvListOfUnavailableWarranty.AutoGenerateColumns = true;
                    dgvListOfUnavailableWarranty.DataSource = ds.Tables[0];
                    dgvListOfUnavailableWarranty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có sản phẩm nào đã hết hạn bảo hành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListOfUnavailableWarranty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu cần xử lý click vào từng ô
        }

        private void dgvListOfUnavailableWarranty_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
