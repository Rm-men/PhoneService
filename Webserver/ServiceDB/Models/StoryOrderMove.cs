using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class StoryOrderMove
    {
        public int Idmove { get; set; }
        public int? Idorder { get; set; }
        public int? Idhuman { get; set; }
        public string Idoldstatus { get; set; }
        public string Idnewstatus { get; set; }
        public int? Idoldaddress { get; set; }
        public int? Idnewaddress { get; set; }
        public DateTime? Somdate { get; set; }

        public virtual Employee IdhumanNavigation { get; set; }
        public virtual ListWorkshop IdnewaddressNavigation { get; set; }
        public virtual OrderStatus IdnewstatusNavigation { get; set; }
        public virtual ListWorkshop IdoldaddressNavigation { get; set; }
        public virtual OrderStatus IdoldstatusNavigation { get; set; }
        public virtual Order IdorderNavigation { get; set; }
    }
}
