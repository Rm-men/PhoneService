using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Phone
    {
        public string Imei { get; set; } = null!;
        public string? IdPhoneModel { get; set; }

        public virtual PhoneModel? IdPhoneModelNavigation { get; set; }
    }
}
