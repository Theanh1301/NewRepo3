using System;
using System.Collections.Generic;

namespace Shopee.Models
{
    public partial class Product
    {
        public Product()
        {
            FlashSales = new HashSet<FlashSale>();
            OrderProducts = new HashSet<OrderProduct>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string? Manufacturer { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public int CategoryId { get; set; }
        public int SaleId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User Sale { get; set; } = null!;
        public virtual ICollection<FlashSale> FlashSales { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
