namespace Shopee.Data
{
    public class ProductData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        /* public decimal UnitPrice { get; set; }
         public int UnitInStock { get; set; }
         public string Manufacturer { get; set; } = null!;
         public string Image { get; set; } = null!;
         public string Details { get; set; } = null!;
        */
        public int CategoryID { get; set; }
        //public int SaleID { get; set; }
    }
}
