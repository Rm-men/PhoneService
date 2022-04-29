using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
            PushareAgreements = new HashSet<PushareAgreement>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PushareAgreement> PushareAgreements { get; set; }
    }
}
