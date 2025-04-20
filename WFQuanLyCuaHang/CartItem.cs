using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFQuanLyCuaHang
{
    public class CartItem
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int SupplierID { get; set; }

        public decimal Total => Price * Quantity;
        public CartItem(int productId, int supplierId, string productName, decimal price, int quantity )
        {
            ProductID = productId;
            SupplierID = supplierId;
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }
        public decimal TotalPrice()
        {
            return Price * Quantity;
        }

    }
}
