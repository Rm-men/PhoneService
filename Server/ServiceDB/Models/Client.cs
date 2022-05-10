using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
