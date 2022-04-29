using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Component
    {
        public string IdComponent { get; set; }
        public string TypeC { get; set; }
        public string Name { get; set; }
        public string IdGuarantee { get; set; }
        public string Manufacturer { get; set; }
        public string IdProduct { get; set; }

        public virtual Guarantee IdGuaranteeNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual Manufacturer ManufacturerNavigation { get; set; }
    }
}
