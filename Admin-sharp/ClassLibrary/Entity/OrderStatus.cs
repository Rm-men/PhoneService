using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public string IdOrderStatus { get; set; }
        public string DescriptionOrderStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
