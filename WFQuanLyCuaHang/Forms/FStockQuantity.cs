using BusinessLogicLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FStockQuantity : Form
    {
        // Biến toàn cục để dùng ở nhiều phương thức
        private DBStock dbStock;
        private DataSet ds;

        public FStockQuantity()
        {
            InitializeComponent(); // Khởi tạo giao diện

            // Khởi tạo lớp lấy dữ liệu và lấy dữ liệu luôn sau khi khởi tạo xong giao diện
            dbStock = new DBStock();
            ds = dbStock.GetStock();
        }

        private void FStockQuantity_Load(object sender, EventArgs e)
        {
            try
            {
                // Làm sạch lưới trước khi nạp dữ liệu
                dtGridView_StockQuantity.DataSource = null;
                dtGridView_StockQuantity.Rows.Clear();
                dtGridView_StockQuantity.Columns.Clear();

                // Kiểm tra dữ liệu rồi gán vào DataGridView
                if (ds != null && ds.Tables.Count > 0)
                {
                    dtGridView_StockQuantity.AutoGenerateColumns = true;
                    dtGridView_StockQuantity.DataSource = ds.Tables[0];
                    dtGridView_StockQuantity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtGridView_StockQuantity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý click vào từng ô nếu cần
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            // Xử lý nếu label này có chức năng
        }
    }
}
