using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataAccessLayer;
using static BusinessLogicLayer.DBOrder;

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
            public int SupplierID { get; set; }


            public ImportDetail() { }

            public ImportDetail(int productID, int quantity, decimal price, int supplierID)
            {
                ProductID = productID;
                Quantity = quantity;
                Price = price;
                SupplierID = supplierID;
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
                "SELECT [ImportID], [EmployeeID], [ImportDate], [TotalCost], [Status] FROM [Import]",
                CommandType.Text,
                null
            );
        }

        // Lấy toàn bộ chi tiết phiếu nhập
        public DataTable GetImportDetails()
        {
            return db.ExecuteQueryDataSet(
                "SELECT [ImportID], [ProductID], [SupplierID], [Quantity], [Price] FROM [ImportDetail]",
                CommandType.Text
            ).Tables[0];
        }

        // Thêm mới phiếu nhập đầy đủ: Import + ImportDetail (TVP + Output)
        // Thêm phiếu nhập (nếu không có chi tiết)

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


        public bool CreateFullImport(ref string err, int EmployeeID, DateTime ImportDate,
                                    decimal TotalCost,List<ImportDetail> importDetails, ref int NewImportID)
        {
            try
            {

                // Tạo DataTable từ list chi tiết
                DataTable tvp = new DataTable();
                tvp.Columns.Add("ProductID", typeof(int));
                tvp.Columns.Add("SupplierID", typeof(int));
                tvp.Columns.Add("Quantity", typeof(int));
                tvp.Columns.Add("Price", typeof(decimal));

                foreach (var item in importDetails)
                {
                    // Kiểm tra dữ liệu đầu vào trước khi thêm vào DataTable
                    if (item.ProductID <= 0 || item.SupplierID <= 0 || item.Quantity <= 0 || item.Price <= 0)
                    {
                        err = $"Lỗi dữ liệu: ProductID={item.ProductID}, SupplierID={item.SupplierID}, Quantity={item.Quantity}, Price={item.Price}";
                        return false; // Dừng luôn để không gây lỗi hệ thống
                    }

                    // Thêm dòng hợp lệ vào DataTable
                    tvp.Rows.Add(item.ProductID, item.SupplierID, item.Quantity, item.Price);
                }

                // Tạo tham số
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = EmployeeID },
                    new SqlParameter("@ImportDate", SqlDbType.DateTime) { Value = ImportDate },
                    new SqlParameter("@TotalCost", SqlDbType.Decimal) { Value = TotalCost },
                    new SqlParameter("@ImportDetail", SqlDbType.Structured)
                    {
                        TypeName = "dbo.ImportDetailsType",
                        Value = tvp
                    },
                    new SqlParameter("@NewImportID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };

                // Gọi stored procedure
                bool result = db.MyExecuteNonQuery("CreateFullImport", CommandType.StoredProcedure, ref err, parameters);

                if (result)
                {
                    var outputParam = parameters.FirstOrDefault(p => p.ParameterName == "@NewImportID");
                    if (outputParam != null && outputParam.Value != DBNull.Value)
                    {
                        NewImportID = Convert.ToInt32(outputParam.Value);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
    }
}
