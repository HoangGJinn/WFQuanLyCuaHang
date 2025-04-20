using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFQuanLyCuaHang.ProductControl; //use UcProduct

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormAddImport1 : Form
    {
        public string username;
        public string usertype;
        private DBProduct dbp;
        private DBAccount dba;
        //List cart
        List<CartItem> cart = new List<CartItem>();



        public FormAddImport1(string username, string usertype)
        {
            InitializeComponent();
            dbp = new DBProduct();
            this.username = username;
            this.usertype = usertype;
            txtProductName.Text = "Hãy chọn sản phẩm!";
            if (usertype == "Customer")
            {
                btnCreateImport.Visible = false;
                dgvCart.Visible = false;
            }

        }

        private void FormAddImport1_Load(object sender, EventArgs e)
        {
            LoadLaptopintoLayout();
            iconButton1.Enabled = false;

        }
        private void lblDatetime_Click(object sender, EventArgs e)
        {

        }
        //Load laptop
        private void LoadLaptopintoLayout()
        {
            flowLayoutPanel2.Controls.Clear(); // Xóa sản phẩm cũ nếu có
            DataSet dsLaptop = dbp.GetLaptops();

            foreach (DataRow row in dsLaptop.Tables[0].Rows)
            {
                int ProductID = Convert.ToInt32(row["ProductID"]);

                // Tạo mới ucProduct và gắn sự kiện
                ucProduct ucProduct = new ucProduct(this);
                ucProduct.OnAddToCart += AddToCart; // 🔥 Gắn sự kiện tại đây

                //Remove
                ucProduct.OnRemoveFromCart += RemoveFromCart;

                // Đăng ký sự kiện cập nhật giỏ hàng khi số lượng thay đổi
                ucProduct.OnUpdateCart += UpdateCart;

                // Load thông tin sản phẩm
                ucProduct.LoadProduct(ProductID);

                // Thêm vào layout
                flowLayoutPanel2.Controls.Add(ucProduct);
            }
        }

        //Load sản phẩm không phải laptop
        private void LoadOrtherintoLayout()
        {
            flowLayoutPanel2.Controls.Clear();
            DataSet dsLaptop = dbp.GetProductsExceptLaptop();
            foreach (DataRow row in dsLaptop.Tables[0].Rows)
            {
                int ProductID = Convert.ToInt32(row["ProductID"]);
                // Tạo mới ucProduct và gắn sự kiện
                ucProduct ucProduct = new ucProduct(this);
                ucProduct.OnAddToCart += AddToCart; // 🔥 Gắn sự kiện tại đây

                //Remove
                ucProduct.OnRemoveFromCart += RemoveFromCart;

                // Đăng ký sự kiện cập nhật giỏ hàng khi số lượng thay đổi
                ucProduct.OnUpdateCart += UpdateCart;

                // Load thông tin sản phẩm
                ucProduct.LoadProduct(ProductID);
                // Thêm vào layout
                flowLayoutPanel2.Controls.Add(ucProduct);
            }
        }


        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                int x = flowLayoutPanel2.Width - 1;
                int y = 0;
                int width = 1;
                int height = flowLayoutPanel2.Height;
                e.Graphics.DrawLine(pen, x, y, x, height);
            }
        }

        private void txtHello_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void HienThiChiTietSanPham(string ten, string gia, string moTa)
        {
            txtProductName.Text = ten;
            TxtPrice.Text = gia;
            txtDescription.Text = moTa; // Label hiển thị mô tả
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            iconButton1.Enabled = true;

            iconButton2.Enabled = false;

            LoadOrtherintoLayout();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton2.Enabled = true;

            iconButton1.Enabled = false;

            LoadLaptopintoLayout();
        }

        // Hàm xử lý khi sản phẩm được thêm từ ucProduct
        public void AddToCart(int productId, int supplierID, string productName, decimal price)
        {
            if (cart == null)
                cart = new List<CartItem>(); // Đảm bảo đã khởi tạo

            var existing = cart.FirstOrDefault(p => p.ProductID == productId);
            if (existing != null)
            {
                existing.Quantity += 1;
            }
            else
            {
                cart.Add(new CartItem(productId, supplierID, productName, price, 1 ));
            }

            LoadCartToGrid();
        }

        private void RemoveFromCart(int productId)
        {
            var itemToRemove = cart.FirstOrDefault(c => c.ProductID == productId);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
                // Có thể cập nhật giao diện hoặc thông báo
                Console.WriteLine($"Đã xóa sản phẩm có ID {productId} khỏi giỏ hàng.");
                LoadCartToGrid();
            }
        }



        private void LoadCartToGrid()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = cart.Select(c => new
            {
                Mã = c.ProductID,
                Ncc = c.SupplierID,
                Tên = c.ProductName,
                Giá = c.Price.ToString("N0") + "đ",
                Số_Lượng = c.Quantity,
                Tổng = c.TotalPrice().ToString("N0") + "đ"
            }).ToList();

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void ResetCartButtons()
        {
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is ucProduct uc)
                {
                    uc.ResetOrderButton();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();

            foreach (Control ctrl in flowLayoutPanel2.Controls)
            {
                if (ctrl is ucProduct uc)
                {
                    bool match = uc.ProductName.ToLower().Contains(keyword);
                    uc.Visible = match;
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        // Hàm cập nhật giỏ hàng khi số lượng thay đổi
        public void UpdateCart(int productId, int quantity)
        {
            var existingItem = cart.FirstOrDefault(c => c.ProductID == productId);
            if (existingItem != null)
            {
                existingItem.Quantity = quantity;  // Cập nhật số lượng sản phẩm trong giỏ
            }

            // Cập nhật giao diện giỏ hàng
            LoadCartToGrid();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerClock_Tick(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreateImport_Click_1(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }


            decimal totalAmount = cart.Sum(item => item.TotalPrice());
            var formCreateImport = new FCreateImport(cart, username, usertype, totalAmount);
            formCreateImport.ShowDialog();

            // Sau khi formOrder hoàn tất
            if (formCreateImport.OrderPlacedSuccessfully)
            {
                cart.Clear();
                LoadCartToGrid();
                ResetCartButtons();
            }
        }
    }
}
