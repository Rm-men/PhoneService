using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Phone
    {
        public Phone()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Imei { get; set; }
        public int? IdPhoneModel { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
