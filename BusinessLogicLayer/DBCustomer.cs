using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBCustomer
    {
        private DAL db;

        public DBCustomer()
        {
            db = DALManager.Instance; // Sử dụng DAL duy nhất
        }

        // Lấy danh sách khách hàng
        public DataSet GetCustomers()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Customer", CommandType.Text, null);
        }

        // Thêm khách hàng mới
        public bool AddCustomer(ref string err, string FullName, string Phone, string Address)
        {
            return db.MyExecuteNonQuery("spInsertCustomer", CommandType.StoredProcedure, ref err,
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@Phone", (object)Phone ?? DBNull.Value),
                new SqlParameter("@Address", (object)Address ?? DBNull.Value));
        }

        // Cập nhật thông tin khách hàng
        public bool UpdateCustomer(ref string err, int CustomerID, string FullName, string Phone, string Address)
        {
            return db.MyExecuteNonQuery("spUpdateCustomer", CommandType.StoredProcedure, ref err,
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@Phone", Phone),
                new SqlParameter("@Address", Address));
        }

        // Xóa khách hàng
        public bool DeleteCustomer(ref string err, int CustomerID)
        {
            return db.MyExecuteNonQuery("spDeleteCustomer", CommandType.StoredProcedure, ref err,
                new SqlParameter("@CustomerID", CustomerID));
        }

        // Tìm kiếm khách hàng theo tên
        public DataSet SearchCustomerByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên khách hàng không được để trống.");

            string query = "SELECT * FROM dbo.SearchCustomerByName(@Name)";
            return db.ExecuteQueryDataSet(query, CommandType.Text,
                new SqlParameter("@Name", name));
        }
    }
}
