using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DBOrder
    {
        // Lớp OrderDetail dùng để truyền danh sách chi tiết đơn hàng
        public class OrderDetail
        {
            public int ProductID { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }

            public OrderDetail() { }

            public OrderDetail(int productID, int quantity, decimal price)
            {
                ProductID = productID;
                Quantity = quantity;
                Price = price;
            }
        }

        private DAL db;

        public DBOrder()
        {
            db = DALManager.Instance; // Dùng Singleton
        }

        // Lấy danh sách đơn hàng
        public DataSet GetOrders()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM [Order]", CommandType.Text, null);
        }

        // Thêm đơn hàng mới
        public bool AddOrder(ref string err, int CustomerID, int EmployeeID, DateTime OrderDate, decimal TotalAmount, string Status, string PaymentMethod, string ShippingAddress)
        {
            return db.MyExecuteNonQuery("spInsertOrder", CommandType.StoredProcedure, ref err,
                new SqlParameter("@CustomerID", CustomerID),
                new SqlParameter("@EmployeeID", EmployeeID),
                new SqlParameter("@OrderDate", OrderDate),
                new SqlParameter("@TotalAmount", TotalAmount),
                new SqlParameter("@Status", Status),
                new SqlParameter("@PaymentMethod", PaymentMethod),
                new SqlParameter("@ShippingAddress", ShippingAddress));
        }

        // Cập nhật trạng thái đơn hàng
        public bool UpdateOrderStatus(ref string err, int OrderID, string Status)
        {
            return db.MyExecuteNonQuery("spUpdateOrderStatus", CommandType.StoredProcedure, ref err,
                new SqlParameter("@OrderID", OrderID),
                new SqlParameter("@Status", Status));
        }

        // Xóa đơn hàng
        public bool DeleteOrder(ref string err, int OrderID)
        {
            return db.MyExecuteNonQuery("spDeleteOrder", CommandType.StoredProcedure, ref err,
                new SqlParameter("@OrderID", OrderID));
        }

        // Lấy đơn hàng chưa giao (View)
        public DataSet GetPendingOrders()
        {
            string query = "SELECT * FROM View_PendingOrders";
            return db.ExecuteQueryDataSet(query, CommandType.Text, null);
        }


        // Tạo đơn hàng + chi tiết đơn hàng (TVP + Output)
        public bool CreateFullOrder(ref string err, int CustomerID, int EmployeeID, DateTime OrderDate,
                                    decimal TotalAmount, string PaymentMethod, string ShippingAddress,
                                    List<OrderDetail> orderDetails, ref int NewOrderID)
        {
            try
            {
                // Tạo DataTable từ list chi tiết
                DataTable tvp = new DataTable();
                tvp.Columns.Add("ProductID", typeof(int));
                tvp.Columns.Add("Quantity", typeof(int));
                tvp.Columns.Add("Price", typeof(decimal));

                foreach (var item in orderDetails)
                {
                    tvp.Rows.Add(item.ProductID, item.Quantity, item.Price);
                }

                // Tạo tham số
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@CustomerID", SqlDbType.Int) { Value = CustomerID },
                    new SqlParameter("@EmployeeID", SqlDbType.Int) { Value = EmployeeID },
                    new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = OrderDate },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = TotalAmount },
                    new SqlParameter("@PaymentMethod", SqlDbType.NVarChar, 50) { Value = PaymentMethod },
                    new SqlParameter("@ShippingAddress", SqlDbType.NVarChar, 255) { Value = ShippingAddress },
                    new SqlParameter("@OrderDetails", SqlDbType.Structured)
                    {
                        TypeName = "dbo.OrderDetailsType",
                        Value = tvp
                    },
                    new SqlParameter("@NewOrderID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    }
                };

                // Gọi stored procedure
                bool result = db.MyExecuteNonQuery("CreateFullOrder", CommandType.StoredProcedure, ref err, parameters);

                if (result)
                {
                    NewOrderID = Convert.ToInt32(parameters[7].Value);
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
