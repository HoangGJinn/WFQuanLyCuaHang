using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBStock
    {
        DAL db;

        public DBStock()
        {
            db = DALManager.Instance; // Sử dụng Singleton DAL
        }

        // Lấy danh sách tồn kho
        public DataSet GetStock()
        {
            return db.ExecuteQueryDataSet("spGetAllStock", CommandType.StoredProcedure, null);
        }

        // Cập nhật số lượng tồn kho
        public bool UpdateStock(ref string err, int ProductID, int Quantity)
        {
            return db.MyExecuteNonQuery("spUpdateStock", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@Quantity", Quantity));
        }
    }
}
