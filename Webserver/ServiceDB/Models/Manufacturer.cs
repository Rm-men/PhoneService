using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
        }

        public int IdManufacturer { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
    }
}
