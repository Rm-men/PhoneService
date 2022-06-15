using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Component
    {
        public Component()
        {
            ComponentsComplibilities = new HashSet<ComponentsComplibility>();
            OnOrderCmps = new HashSet<OnOrderCmp>();
        }

        public int IdComponent { get; set; }
        public string Typecmp { get; set; }
        public string Namecmp { get; set; }
        public int? IdGuaranteecmp { get; set; }
        public int Manufacturercmp { get; set; }
        public decimal? Pricecmp { get; set; }
        public int? Count { get; set; }

        public virtual Guarantee IdGuaranteecmpNavigation { get; set; }
        public virtual Manufacturer ManufacturercmpNavigation { get; set; }
        public virtual ICollection<ComponentsComplibility> ComponentsComplibilities { get; set; }
        public virtual ICollection<OnOrderCmp> OnOrderCmps { get; set; }
    }
}
