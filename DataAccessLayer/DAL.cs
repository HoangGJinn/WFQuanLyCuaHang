using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DAL
    {
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;

        private static string defaultConnStr = @"Data Source=LAPTOP-L65KCPF3\SQLEXPRESS;Initial Catalog=LaptopStore2;Integrated Security=True";

        public DAL()
        {
            conn = new SqlConnection(defaultConnStr);
            comm = conn.CreateCommand();
        }
        // Constructor không khởi tạo ConnStr mà để bên ngoài truyền vào
        public DAL(string dynamicConnStr)
        {
            // Tạo kết nối với chuỗi kết nối động
            conn = new SqlConnection(dynamicConnStr);
            comm = conn.CreateCommand();
        }

        // Khai báo phương thức thực thi truy vấn và trả về DataSet
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            comm.Parameters.Clear();
            if (p != null && p.Length > 0)
            {
                comm.Parameters.AddRange(p);
            }
            da.Fill(ds);
            return ds;
        }

        // Thực thi các Action Query (Insert, Delete, Update) hoặc Stored Procedure
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        // Thực thi câu lệnh và trả về DataTable
        public DataTable ExecuteQueryDataTable(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Parameters.Clear();

            if (p != null && p.Length > 0)
            {
                comm.Parameters.AddRange(p);
            }

            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();
            return dt;
        }

        // Thực thi câu lệnh ExecuteScalar
        public object ExecuteScalar(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(this.conn.ConnectionString))  // Dùng kết nối động từ đối tượng DAL
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteScalar();  // Thực thi và lấy kết quả đầu tiên
                }
            }
            return result;
        }

    }
}
