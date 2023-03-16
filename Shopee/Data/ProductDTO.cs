namespace Shopee.Data
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string? Manufacturer { get; set; }
        public string? Image { get; set; }
        public string? Details { get; set; }
        public string CategoryName { get; set; }
        public string Saler { get; set; }
    }
}
