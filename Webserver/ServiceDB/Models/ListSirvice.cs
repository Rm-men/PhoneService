using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class ListSirvice
    {
        public ListSirvice()
        {
            OnOrderSrvs = new HashSet<OnOrderSrv>();
        }

        public int Id { get; set; }
        public string Namesrv { get; set; }
        public string Typesrv { get; set; }
        public string Descriptionsrv { get; set; }
        public decimal? Costsrv { get; set; }
        public string Timesrv { get; set; }

        public virtual ICollection<OnOrderSrv> OnOrderSrvs { get; set; }

    }
}
