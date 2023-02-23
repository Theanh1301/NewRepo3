using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class OrderProduct
    {
        public int Id { get; set; }
        public int Oid { get; set; }
        public int Pid { get; set; }
        public int? Quantity { get; set; }

        public virtual Order OidNavigation { get; set; } = null!;
        public virtual Product PidNavigation { get; set; } = null!;
    }
}
