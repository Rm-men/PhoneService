using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
        }

        public string IdManufacturer { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
    }
}
