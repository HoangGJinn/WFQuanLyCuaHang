using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBWarranty
    {
        DAL db;
        public DBWarranty()
        {
            db = DALManager.Instance; // Sử dụng Singleton DAL
        }

        // Lấy danh sách bảo hành
        public DataSet GetWarranties()
        {
            return db.ExecuteQueryDataSet("spGetAllWarranties", CommandType.StoredProcedure, null);
        }

        // Thêm bảo hành mới
        public bool AddWarranty(ref string err, int ProductID, int CustomerID, DateTime StartDate, DateTime EndDate, string Status, string WarrantyCenter)
        {
            return db.MyExecuteNonQuery("spInsertWarranty", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@Status", Status),
                new SqlParameter("@WarrantyCenter", WarrantyCenter));
        }

        // Cập nhật thông tin bảo hành
        public bool UpdateWarranty(ref string err, int WarrantyID, int ProductID, int CustomerID, DateTime StartDate, DateTime EndDate, string Status, string WarrantyCenter)
        {
            return db.MyExecuteNonQuery("spUpdateWarranty", CommandType.StoredProcedure, ref err,
                new SqlParameter("@WarrantyID", WarrantyID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@StartDate", StartDate),
                new SqlParameter("@EndDate", EndDate),
                new SqlParameter("@Status", Status),
                new SqlParameter("@WarrantyCenter", WarrantyCenter));
        }

        // Xóa bảo hành
        public bool DeleteWarranty(ref string err, int WarrantyID)
        {
            return db.MyExecuteNonQuery("spDeleteWarranty", CommandType.StoredProcedure, ref err,
                new SqlParameter("@WarrantyID", WarrantyID));
        }
    }
}