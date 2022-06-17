using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class PhoneModel
    {
        public PhoneModel()
        {
            ComponentsComplibilities = new HashSet<ComponentsComplibility>();
            Phones = new HashSet<Phone>();
        }

        public int IdPhoneModel { get; set; }
        public string Namephone { get; set; }
        public string Specifications { get; set; }
        public int? Guarantee { get; set; }
        public int? Manufacturer { get; set; }

        public virtual Guarantee GuaranteeNavigation { get; set; }
        public virtual Manufacturer ManufacturerNavigation { get; set; }
        public virtual ICollection<ComponentsComplibility> ComponentsComplibilities { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
