using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBOrderDetail
    {
        private DAL db;

        public DBOrderDetail()
        {
            db = DALManager.Instance; // Dùng Singleton thay vì new DAL()
        }

        // Thêm chi tiết đơn hàng
        public bool AddOrderDetail(ref string err, int OrderID, int ProductID, int Quantity, decimal Price)
        {
            return db.MyExecuteNonQuery("spInsertOrderDetail", CommandType.StoredProcedure, ref err,
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@Price", Price));
        }

        // Lấy danh sách chi tiết đơn hàng
        public DataSet GetOrderInfo(int OrderID)
        {
            return db.ExecuteQueryDataSet("spGetOrderInfo", CommandType.StoredProcedure,
                new SqlParameter("@OrderID", OrderID));
        }

        // Cập nhật chi tiết đơn hàng
        public bool UpdateOrderDetail(ref string err, int OrderID, int ProductID, int Quantity, decimal Price)
        {
            string sql = "UPDATE OrderDetails SET Quantity = @Quantity, Price = @Price WHERE OrderID = @OrderID AND ProductID = @ProductID";

            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err,
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@Quantity", Quantity),
                new SqlParameter("@Price", Price));
        }

        // Xóa chi tiết đơn hàng
        public bool DeleteOrderDetail(ref string err, int OrderID, int ProductID)
        {
            string sql = "DELETE FROM OrderDetails WHERE OrderID = @OrderID AND ProductID = @ProductID";
            return db.MyExecuteNonQuery(sql, CommandType.Text, ref err,
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@ProductID", ProductID));
        }
    }
}
