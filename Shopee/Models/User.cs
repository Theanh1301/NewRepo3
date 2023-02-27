using System;
using System.Collections.Generic;

namespace Shopee.Models
{
    public partial class User
    {
        public User()
        {
            ChatHistories = new HashSet<ChatHistory>();
            Products = new HashSet<Product>();
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public int Role { get; set; }

        public virtual ICollection<ChatHistory> ChatHistories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
