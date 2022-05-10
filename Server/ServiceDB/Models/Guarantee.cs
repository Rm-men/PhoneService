using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Guarantee
    {
        public Guarantee()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
        }

        public string IdGuarantee { get; set; } = null!;
        public int? PeriodInMonths { get; set; }
        public string? Conditions { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
    }
}
