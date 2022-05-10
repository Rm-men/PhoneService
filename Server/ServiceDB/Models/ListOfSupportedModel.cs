using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class ListOfSupportedModel
    {
        public string IdListOfSupModels { get; set; } = null!;
        public string? ListSupmodelName { get; set; }
        public string? IdComponent { get; set; }
        public string? IdPhoneModel { get; set; }

        public virtual Component? IdComponentNavigation { get; set; }
        public virtual PhoneModel? IdPhoneModelNavigation { get; set; }
    }
}
