using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BusinessLogicLayer;
using WFQuanLyCuaHang.Forms;
using System.Diagnostics;

namespace WFQuanLyCuaHang.ProductControl
{
    public partial class ucProduct : UserControl
    {
        private DBProduct dbp;
        private FormHomeDesktop frmHome;
        public int quantity = 1; // Biến lưu lại số lượng sản phẩm trong giỏ hàng

        // Biến lưu lại thông tin sản phẩm
        private int ProductID;
        public string ProductName { get; private set; }
        private decimal Price;
        private FormAddImport1 formAddImport1;

        // Delegate cho sự kiện thêm vào giỏ hàng
        public delegate void AddToCartHandler(int productId, string productName, decimal price);
        public event AddToCartHandler OnAddToCart;
        //Remove
        public delegate void RemoveFromCartHandler(int productId);
        public event RemoveFromCartHandler OnRemoveFromCart;
        //
        public delegate void UpdateCartHandler(int productId, int quantity);
        public event UpdateCartHandler OnUpdateCart;


        public ucProduct(FormHomeDesktop frmHome)
        {
            InitializeComponent();
            dbp = new DBProduct();
            this.frmHome = frmHome;
            if(frmHome.usertype == "Customer")
            {
                btnOrder.Visible = false;
            }
            else
            {
                btnOrder.Visible = true;
            }
        }

        public ucProduct(FormAddImport1 formAddImport1)
        {
            InitializeComponent();
            dbp = new DBProduct();
            this.formAddImport1 = formAddImport1;
            if (formAddImport1.usertype == "Customer")
            {
                btnOrder.Visible = false;
            }
            else
            {
                btnOrder.Visible = true;
            }
        }

        private void ucProduct_Load(object sender, EventArgs e)
        {

        }

        public void LoadProduct(int productID)
        {
            DataSet ds = dbp.GetPicture(productID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                // Gán vào các biến lớp
                this.ProductID = productID;
                this.ProductName = row["ProductName"].ToString();
                this.Price = Convert.ToDecimal(row["Price"]);

                label1.Text = ProductName;
                label2.Text = Price.ToString("N0") + "đ";

                // Load ảnh
                byte[] imageBytes = row["Image"] as byte[];
                if (imageBytes != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        // Nếu lỗi ảnh, dùng ảnh mặc định
                        pictureBox1.Image = Properties.Resources._ff00cc__1__removebg_preview1;
                    }
                }
                else
                {
                    pictureBox1.Image = Properties.Resources._ff00cc__1__removebg_preview1;
                }

                label1.Tag = ProductID;
                label2.Tag = ProductName;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (label1.Tag != null && int.TryParse(label1.Tag.ToString(), out int maSanPham))
            {
                DataSet ds = dbp.GetPicture(maSanPham); // Gọi lại để lấy dữ liệu đầy đủ
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    string ten = row["ProductName"].ToString();
                    string moTa = row["Description"].ToString().Replace(",", Environment.NewLine);
                    decimal gia = Convert.ToDecimal(row["Price"]);
                    string giaText = gia.ToString("N0") + "đ";

                    frmHome.HienThiChiTietSanPham(ten, giaText, moTa);
                }
            }
            else
            {
                MessageBox.Show("Không thể lấy mã sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (btnOrder.Text == "Thêm vào giỏ hàng")
            {
                btnOrder.Text = "Đã thêm";
                btnOrder.BackColor = Color.FromArgb(255, 224, 192); // Màu cam nhạt

                //
                btnDecrease.Visible = true;
                btnIncrease.Visible = true;

                // Gọi sự kiện nếu có người đăng ký
                OnAddToCart?.Invoke(ProductID, ProductName, Price);

            }
            else
            {

                // Gọi sự kiện xóa khỏi giỏ (nếu có)
                OnRemoveFromCart?.Invoke(ProductID);

                btnOrder.Text = "Thêm vào giỏ hàng";
                btnOrder.BackColor = Color.White;

                btnDecrease.Visible = false;
                btnIncrease.Visible = false;
            }
        }

        public void ResetOrderButton()
        {
            btnOrder.Text = "Thêm vào giỏ hàng";
            btnOrder.BackColor = Color.White;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        // Nút tăng số lượng
        private void btnIncrease_Click(object sender, EventArgs e)
        {
            quantity++;  // Tăng số lượng

            // Cập nhật giỏ hàng
            OnUpdateCart?.Invoke(ProductID, quantity);
        }

        // Nút giảm số lượng
        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if (quantity > 1)  // Đảm bảo không giảm dưới 1
            {
                quantity--;  // Giảm số lượng

                // Cập nhật giỏ hàng
                OnUpdateCart?.Invoke(ProductID, quantity);
            }
        }

    }
}
