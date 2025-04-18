using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBImportDetail
    {
        private DAL db;

        public DBImportDetail()
        {
            db = DALManager.Instance; // Dùng singleton pattern
        }

        // Thêm chi tiết nhập hàng
        public bool AddImportDetail(ref string err, int importID, int productID, int quantity, decimal price)
        {
            return db.MyExecuteNonQuery("spInsertImportDetail", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ImportID", importID),
                new SqlParameter("@ProductID", productID),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@Price", price));
        }

        // Lấy danh sách chi tiết của một phiếu nhập
        public DataSet GetImportDetailsByImportID(int importID)
        {
            return db.ExecuteQueryDataSet("spGetImportDetailsByImportID", CommandType.StoredProcedure,
                new SqlParameter("@ImportID", importID));
        }

        // Cập nhật chi tiết nhập hàng
        public bool UpdateImportDetail(ref string err, int importID, int productID, int quantity, decimal price)
        {
            string sql = "UPDATE ImportDetail SET Quantity = @Quantity, Price = @Price WHERE ImportID = @ImportID AND ProductID = @ProductID";

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err,
                new SqlParameter("@ImportID", importID),
                new SqlParameter("@ProductID", productID),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@Price", price));
        }

        // Xóa chi tiết nhập hàng
        public bool DeleteImportDetail(ref string err, int importID, int productID)
        {
            string sql = "DELETE FROM ImportDetail WHERE ImportID = @ImportID AND ProductID = @ProductID";

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err,
                new SqlParameter("@ImportID", importID),
                new SqlParameter("@ProductID", productID));
        }
        


    }
}
