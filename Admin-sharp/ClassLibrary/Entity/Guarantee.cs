using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Guarantee
    {
        public Guarantee()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
        }

        public string IdGuarantee { get; set; }
        public int? GarrantyPeriodInMonths { get; set; }
        public string GarrantyConditions { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
    }
}
