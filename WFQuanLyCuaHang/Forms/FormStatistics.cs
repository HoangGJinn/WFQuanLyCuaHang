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
    public partial class FormStatistics: Form
    {
        string connectionString = @"Data Source=.;Initial Catalog=LaptopStore2;Integrated Security=True";

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
        }

        //doanh thu của tháng hiện tại
        private void LoadRevenueByMonth(int month, int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetRevenueByMonthYear", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Year", year);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgv_DThu.DataSource = dt;

                            dgv_DThu.Columns["OrderID"].HeaderText = "OrderID";
                            dgv_DThu.Columns["CustomerID"].HeaderText = "CustomerID";
                            dgv_DThu.Columns["EmployeeID"].HeaderText = "EmployeeID";
                            dgv_DThu.Columns["Date"].HeaderText = "Date";
                            dgv_DThu.Columns["TotalAmount"].HeaderText = "TotalAmount";

                            dgv_DThu.DefaultCellStyle.Font = new Font("Cambria", 10);
                            dgv_DThu.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 11, FontStyle.Bold);
                            dgv_DThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                            dgv_DThu.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                            dgv_DThu.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRevenueDetailsByYear(int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spGetRevenueDetailsByYear", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Year", year);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgv_DThu.DataSource = dt;

                            // Tùy chỉnh hiển thị cột
                            dgv_DThu.Columns["OrderID"].HeaderText = "OrderID";
                            dgv_DThu.Columns["CustomerID"].HeaderText = "CustomerID";
                            dgv_DThu.Columns["EmployeeID"].HeaderText = "EmployeeID";
                            dgv_DThu.Columns["Date"].HeaderText = "Date";
                            dgv_DThu.Columns["TotalAmount"].HeaderText = "TotalAmount";

                            dgv_DThu.DefaultCellStyle.Font = new Font("Cambria", 10);
                            dgv_DThu.ColumnHeadersDefaultCellStyle.Font = new Font("Cambria", 11, FontStyle.Bold);
                            dgv_DThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dgv_DThu.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                            dgv_DThu.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải đơn hàng theo năm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CbbChoseStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChoseStyle.SelectedItem == null) return;

            DateTime selectedDate = dtpStartDate.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            if (cbbChoseStyle.SelectedItem.ToString() == "Tháng")
            {
                LoadRevenueByMonth(month, year);
                LoadRevenueByYear(year);
                dgv_DThu.Enabled = true;
            }
            else if (cbbChoseStyle.SelectedItem.ToString() == "Năm")
            {
                dgv_DThu.DataSource = null; // Xóa bảng
                LoadRevenueByYear(year);
                dgv_DThu.Enabled = false;
            }
        }

        // tổng doanh thu của năm nay
        private void LoadRevenueByYear(int year)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("spGetRevenueByYear", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Year", year);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        txt_DThuCaNam.Text = Convert.ToDecimal(result).ToString("N0");
                        txt_DThuCaNam.ReadOnly = true;
                    }
                    else
                    {
                        txt_DThuCaNam.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            dgv_DThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpStartDate.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            if (cbbChoseStyle.SelectedItem != null)
            {
                string selectedStyle = cbbChoseStyle.SelectedItem.ToString();

                if (selectedStyle == "Tháng")
                {
                    LoadRevenueByMonth(month, year);
                    LoadRevenueByYear(year);
                    dgv_DThu.Enabled = true;
                }
                else if (selectedStyle == "Năm")
                {
                    LoadRevenueDetailsByYear(year);
                    dgv_DThu.Enabled = true;
                    LoadRevenueByYear(year);
                }
            }
        }

    }
}
