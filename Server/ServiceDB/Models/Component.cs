using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Component
    {
        public Component()
        {
            ListOfSupportedModels = new HashSet<ListOfSupportedModel>();
        }

        public string IdComponent { get; set; } = null!;
        public string TypeC { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? IdGuarantee { get; set; }
        public string Manufacturer { get; set; } = null!;

        public virtual Guarantee? IdGuaranteeNavigation { get; set; }
        public virtual Manufacturer ManufacturerNavigation { get; set; } = null!;
        public virtual ICollection<ListOfSupportedModel> ListOfSupportedModels { get; set; }
    }
}
