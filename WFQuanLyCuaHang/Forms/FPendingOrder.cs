using BusinessLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FPendingOrder : Form
    {
        private DBOrder dbOrder; // BLL xử lý đơn hàng
        private DataSet ds;

        public FPendingOrder()
        {
            InitializeComponent();
            dbOrder = new DBOrder();
            ds = dbOrder.GetPendingOrders();
        }

        private void FPendingOrder_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_PendingOrder.DataSource = null;
                dgv_PendingOrder.Rows.Clear();
                dgv_PendingOrder.Columns.Clear();

                if (ds != null && ds.Tables.Count > 0)
                {
                    dgv_PendingOrder.AutoGenerateColumns = true;
                    dgv_PendingOrder.DataSource = ds.Tables[0];
                    dgv_PendingOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có đơn hàng đang xử lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu đơn hàng:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_PendingOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // xử lý khi click vào một cell nếu cần
        }
    }
}
