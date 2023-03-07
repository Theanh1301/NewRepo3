using System;
using System.Collections.Generic;

namespace Shopee.Models
{
    public partial class ChatHistory
    {
        public int ChatId { get; set; }
        public string ChatContent { get; set; } = null!;
        public DateTime? Date { get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }

        public virtual User UserId1Navigation { get; set; } = null!;
    }
}
