using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class ComponentsComplibility
    {
        public int Idcc { get; set; }
        public int? IdComponent { get; set; }
        public int? IdPhmodel { get; set; }

        public virtual Component IdComponentNavigation { get; set; }
        public virtual PhoneModel IdPhmodelNavigation { get; set; }
    }
}
