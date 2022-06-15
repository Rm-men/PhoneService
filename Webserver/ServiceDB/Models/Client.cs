using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string Namecl { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Clpassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
