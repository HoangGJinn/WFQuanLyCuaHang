using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using WFQuanLyCuaHang.ProductControl;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FormProducts : Form
    {
        public FormProducts()
        {
            InitializeComponent();
            UC_Lap uc = new UC_Lap();
            addUserControl(uc); // Thêm vào panel
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill; // Hiển thị toàn bộ trong Panel
            panelContainer.Controls.Clear();   // Xóa UserControl cũ
            panelContainer.Controls.Add(userControl); // Thêm UserControl mới
            userControl.BringToFront(); // Đưa lên trước
        }


        private void FormProducts_Load(object sender, EventArgs e)
        {

        }


        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOrther_Click(object sender, EventArgs e)
        {
            UC_Orther uc = new UC_Orther();
            addUserControl(uc); // Thêm vào panel
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            UC_Lap uc = new UC_Lap();
            addUserControl(uc); // Thêm vào panel
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
