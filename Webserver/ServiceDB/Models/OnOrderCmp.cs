using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OnOrderCmp
    {
        public int IdCmpOnord { get; set; }
        public int? IdOrderForcomp { get; set; }
        public int? IdCmpOnlist { get; set; }

        public virtual Component IdCmpOnlistNavigation { get; set; }
        public virtual Order IdOrderForcompNavigation { get; set; }
    }
}
