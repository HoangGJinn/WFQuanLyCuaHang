using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBSupplier
    {
        private readonly DAL db;

        public DBSupplier()
        {
            db = DALManager.Instance; // Khuyến nghị dùng Singleton DAL để tiết kiệm tài nguyên
        }

        // Lấy danh sách nhà cung cấp
        public DataSet GetSuppliers()
        {
            return db.ExecuteQueryDataSet("spGetAllSuppliers", CommandType.StoredProcedure);
        }

        // Thêm nhà cung cấp mới
        public bool AddSupplier(ref string err, string name, string contact, string address)
        {
            return db.MyExecuteNonQuery("spInsertSupplier", CommandType.StoredProcedure, ref err,
                new SqlParameter("@Name", name),
                new SqlParameter("@Contact", contact),
                new SqlParameter("@Address", address));
        }

        // Cập nhật thông tin nhà cung cấp
        public bool UpdateSupplier(ref string err, int supplierID, string name, string contact, string address)
        {
            return db.MyExecuteNonQuery("spUpdateSupplier", CommandType.StoredProcedure, ref err,
                new SqlParameter("@SupplierID", supplierID),
                new SqlParameter("@Name", name),
                new SqlParameter("@Contact", contact),
                new SqlParameter("@Address", address));
        }

        // Xóa nhà cung cấp
        public bool DeleteSupplier(ref string err, int supplierID)
        {
            return db.MyExecuteNonQuery("spDeleteSupplier", CommandType.StoredProcedure, ref err,
                new SqlParameter("@SupplierID", supplierID));
        }
    }
}
