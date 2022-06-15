using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OnOrderSrv
    {
        public int IdSrvOnord { get; set; }
        public int? IdOrderForservice { get; set; }
        public int? IdSrvOnlist { get; set; }

        public virtual Order IdOrderForserviceNavigation { get; set; }
        public virtual ListSirvice IdSrvOnlistNavigation { get; set; }
    }
}
