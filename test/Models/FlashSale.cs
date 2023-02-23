using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class FlashSale
    {
        public int Fid { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? UnitPrice { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
