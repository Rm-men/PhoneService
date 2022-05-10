using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? IdClient { get; set; }
        public string? IdOrderStatus { get; set; }

        public virtual Client? IdClientNavigation { get; set; }
        public virtual OrderStatus? IdOrderStatusNavigation { get; set; }
    }
}
