using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public string IdOrderStatus { get; set; } = null!;
        public string? DescriptionOrderStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
