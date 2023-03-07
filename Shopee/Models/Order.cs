using System;
using System.Collections.Generic;

namespace Shopee.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public string? Address { get; set; }
        public decimal? Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
