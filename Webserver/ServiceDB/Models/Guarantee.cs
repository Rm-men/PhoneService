using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Guarantee
    {
        public Guarantee()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
        }

        public int IdGuarantee { get; set; }
        public int? Period { get; set; }
        public string Conditions { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
    }
}
