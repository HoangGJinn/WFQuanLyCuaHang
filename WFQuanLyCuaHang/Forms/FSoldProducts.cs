using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQuanLyCuaHang.Forms
{
    public partial class FSoldProducts: Form
    {
        private DBProduct dbp;
        public FSoldProducts()
        {
            InitializeComponent();
            dbp = new DBProduct();
        }

        private void FSoldProducts_Load(object sender, EventArgs e)
        {
            // Load data when the form loads
            LoadData();
        }

        private void LoadData()
        {
            
            DataTable dt = dbp.GetSoldProductsToday();
            // Load data from database into DataGridView
            dgv_SoldProductsToday.DataSource = dt;

        }


        private void dgv_SoldProductsToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
