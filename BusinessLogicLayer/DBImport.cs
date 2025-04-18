using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBImport
    {
        // Lớp ImportDetail dùng để truyền danh sách chi tiết phiếu nhập
        public class ImportDetail
        {
            public int ProductID { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public ImportDetail() { }

            public ImportDetail(int productID, int quantity, decimal price)
            {
                ProductID = productID;
                Quantity = quantity;
                Price = price;
            }
        }

        private DAL db;

        public DBImport()
        {
            db = DALManager.Instance;
        }

        // Lấy toàn bộ danh sách phiếu nhập
        public DataSet GetImports()
        {
            return db.ExecuteQueryDataSet(
                "SELECT [ImportID], [SupplierID], [EmployeeID], [ImportDate], [TotalCost], [Status] FROM [Import]",
                CommandType.Text,
                null
            );
        }

        // Lấy toàn bộ chi tiết phiếu nhập
        public DataTable GetImportDetails()
        {
            return db.ExecuteQueryDataSet(
                "SELECT [ImportID], [ProductID], [Quantity], [Price] FROM [ImportDetail]",
                CommandType.Text
            ).Tables[0];
        }

        // Thêm mới phiếu nhập đầy đủ: Import + ImportDetail (TVP + Output)
        // Thêm phiếu nhập (nếu không có chi tiết)
        public bool AddImport(ref string err, int SupplierID, int EmployeeID, DateTime ImportDate, decimal TotalCost, string Status)
        {
            return db.MyExecuteNonQuery("spInsertImport", CommandType.StoredProcedure, ref err,
                new SqlParameter("@SupplierID", SupplierID),
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@ImportDate", ImportDate),
                new SqlParameter("@TotalCost", TotalCost),
                new SqlParameter("@Status", Status));
        }
        public bool DeleteImport(ref string err, int ImportID)
        {
            return db.MyExecuteNonQuery("spDeleteImport", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ImportID", ImportID));
        }
        public bool UpdateImportStatus(ref string err, int ImportID, string Status)
        {
            return db.MyExecuteNonQuery("spUpdateImportStatus", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ImportID", ImportID),
                new SqlParameter("@Status", Status));
        }
    }
}
