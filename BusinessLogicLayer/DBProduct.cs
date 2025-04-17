using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBProduct
    {
        DAL db;

        public DBProduct()
        {
            db = DALManager.Instance; // Dùng Singleton
        }

        // Lấy danh sách sản phẩm
        public DataSet GetProducts()
        {
            return db.ExecuteQueryDataSet("spGetAllProducts", CommandType.StoredProcedure, null);
        }

        // Lấy danh sách sản phẩm Laptop
        public DataSet GetLaptops()
        {
            return db.ExecuteQueryDataSet("spGetProductsByCategory", CommandType.StoredProcedure,
                new SqlParameter("@Category", "Laptop"));
        }

        // Lấy danh sách sản phẩm không phải Laptop
        public DataSet GetProductsExceptLaptop()
        {
            string query = "SELECT * FROM Product WHERE Category <> 'Laptop'";
            return db.ExecuteQueryDataSet(query, CommandType.Text);
        }

        // Thêm sản phẩm mới
        public bool AddProduct(ref string err, int SupplierID, string ProductName, string Category, string Brand,
                               decimal Price, int WarrantyPeriod, string Description)
        {
            return db.MyExecuteNonQuery("spInsertProduct", CommandType.StoredProcedure, ref err,
                new SqlParameter("@SupplierID", SupplierID),
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@Category", Category),
                new SqlParameter("@Brand", Brand),
                new SqlParameter("@Price", Price),
                new SqlParameter("@WarrantyPeriod", WarrantyPeriod),
                new SqlParameter("@Description", Description));
        }

        // Cập nhật sản phẩm
        public bool UpdateProduct(ref string err, int ProductID, int SupplierID, string ProductName,
                                  string Category, string Brand, decimal Price, int WarrantyPeriod, string Description)
        {
            return db.MyExecuteNonQuery("spUpdateProduct", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ProductID", ProductID),
                new SqlParameter("@SupplierID", SupplierID),
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@Category", Category),
                new SqlParameter("@Brand", Brand),
                new SqlParameter("@Price", Price),
                new SqlParameter("@WarrantyPeriod", WarrantyPeriod),
                new SqlParameter("@Description", Description));
        }

        // Xóa sản phẩm
        public bool DeleteProduct(ref string err, int ProductID)
        {
            return db.MyExecuteNonQuery("spDeleteProduct", CommandType.StoredProcedure, ref err,
                new SqlParameter("@ProductID", ProductID));
        }

        // Lấy tên sản phẩm theo ID
        public string GetProductNameByID(int ProductID)
        {
            var ds = db.ExecuteQueryDataSet("SELECT ProductName FROM Product WHERE ProductID = @ProductID",
                CommandType.Text, new SqlParameter("@ProductID", ProductID));

            return ds?.Tables[0].Rows.Count > 0
                ? ds.Tables[0].Rows[0]["ProductName"].ToString()
                : string.Empty;
        }

        // Lấy giá sản phẩm theo ID
        public decimal GetProductPriceByID(int ProductID)
        {
            var ds = db.ExecuteQueryDataSet("SELECT Price FROM Product WHERE ProductID = @ProductID",
                CommandType.Text, new SqlParameter("@ProductID", ProductID));

            return ds?.Tables[0].Rows.Count > 0 &&
                   decimal.TryParse(ds.Tables[0].Rows[0]["Price"].ToString(), out var price)
                ? price
                : 0;
        }

        // Tìm laptop theo tên
        public DataSet SearchLaptopByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên laptop không được để trống.");

            return db.ExecuteQueryDataSet("SELECT * FROM dbo.SearchLaptopByName(@Name)", CommandType.Text,
                new SqlParameter("@Name", name));
        }

        // Tìm sản phẩm không phải laptop theo tên
        public DataSet SearchNonLaptopByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên sản phẩm không được để trống.");

            return db.ExecuteQueryDataSet("SELECT * FROM dbo.SearchNonLaptopByName(@Name)", CommandType.Text,
                new SqlParameter("@Name", name));
        }

        // Lấy danh sách sản phẩm đã bán hôm nay (view)
        public DataTable GetSoldProductsToday()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM View_SoldProductsToday", CommandType.Text).Tables[0];
        }

        // Lấy ảnh sản phẩm theo ID
        public DataSet GetPicture(int ProductID)
        {
            return db.ExecuteQueryDataSet("spLayTenHinhAnh", CommandType.StoredProcedure,
                new SqlParameter("@ProductID", ProductID));
        }
    }
}
