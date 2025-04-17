using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBEmployee
    {
        DAL db;
        public DBEmployee()
        {
            db = new DAL();
        }

        // Lấy danh sách nhân viên
        public DataSet GetEmployees()
        {
            return db.ExecuteQueryDataSet("spGetAllEmployees", CommandType.StoredProcedure, null);
        }

        // Thêm nhân viên mới
        public bool AddEmployee(ref string err, string FullName, string Phone, string Address, string Position, decimal Salary, DateTime HireDate, string Status)
        {
            return db.MyExecuteNonQuery("spInsertEmployee", CommandType.StoredProcedure, ref err,
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@Phone", Phone),
                new SqlParameter("@Address", Address),
                new SqlParameter("@Position", Position),
                new SqlParameter("@Salary", Salary),
                new SqlParameter("@HireDate", HireDate),
                new SqlParameter("@Status", Status));
        }

        // Cập nhật thông tin nhân viên
        public bool UpdateEmployee(ref string err, int EmployeeID, string FullName, string Phone, string Address, string Position, decimal Salary, DateTime HireDate, string Status)
        {
            return db.MyExecuteNonQuery("spUpdateEmployee", CommandType.StoredProcedure, ref err,
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@FullName", FullName),
                new SqlParameter("@Phone", Phone),
                new SqlParameter("@Address", Address),
                new SqlParameter("@Position", Position),
                new SqlParameter("@Salary", Salary),
                new SqlParameter("@HireDate", HireDate),
                new SqlParameter("@Status", Status));
        }

        // Xóa nhân viên
        public bool DeleteEmployee(ref string err, int EmployeeID)
        {
            return db.MyExecuteNonQuery("spDeleteEmployee", CommandType.StoredProcedure, ref err,
                new SqlParameter("@EmployeeID", EmployeeID));
        }
        // Tìm kiếm nhân viên theo tên (Funtion)
        public DataSet SearchEmployeeByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên nhân viên không được để trống.");

            string query = "SELECT * FROM dbo.SearchEmployeeByName(@Name)";

            return db.ExecuteQueryDataSet(query, CommandType.Text,
                new SqlParameter("@Name", name));
        }
    }
}
