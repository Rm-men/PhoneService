using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OrdersView
    {
        public int? IdOrder { get; set; }
        public DateTime? Dateord { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public bool? Agreement { get; set; }
        public int? IdClient { get; set; }
        public string Family { get; set; }
        public string Namecl { get; set; }
        public string Patronymic { get; set; }
        public string Namephone { get; set; }
        public string Descriptionos { get; set; }
        public string Descriptionord { get; set; }
        public string Comments { get; set; }
        public int? IdMaster { get; set; }
        public int? IdPhone { get; set; }
        public string IdOrderStatus { get; set; }
        public string Contacts { get; set; }
    }
}
