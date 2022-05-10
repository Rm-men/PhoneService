using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class PhoneModel
    {
        public PhoneModel()
        {
            ListOfSupportedModels = new HashSet<ListOfSupportedModel>();
            Phones = new HashSet<Phone>();
        }

        public string IdPhoneModel { get; set; } = null!;
        public string NameModel { get; set; } = null!;
        public string Specifications { get; set; } = null!;
        public string? GuaranteePhoneModel { get; set; }
        public string? Manufacturer { get; set; }

        public virtual Guarantee? GuaranteePhoneModelNavigation { get; set; }
        public virtual Manufacturer? ManufacturerNavigation { get; set; }
        public virtual ICollection<ListOfSupportedModel> ListOfSupportedModels { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
