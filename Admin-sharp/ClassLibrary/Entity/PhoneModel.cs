using ClassLibrary.EntityFynctions;
using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class PhoneModel
    {
        public string IdPhoneModel { get; set; }
        public string NameModel { get; set; }
        public string Specifications { get; set; }
        public string GuaranteePhoneModel { get; set; }
        public string Manufacturer { get; set; }
        public string IdProduct { get; set; }

        public virtual Guarantee GuaranteePhoneModelNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual Manufacturer ManufacturerNavigation { get; set; }

 
    }
}
