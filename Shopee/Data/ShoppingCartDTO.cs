﻿namespace Shopee.Data
{
    public class ShoppingCartDTO
    {
        public int Sid { get; set; }
        public int? Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
