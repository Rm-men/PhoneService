using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OnOrderCmp
    {
        public class OnOrderCmpInfo
        {
            public int IdCmpOnord { get; set; }
            public int? IdOrderForcomp { get; set; }
            public int? IdCmpOnlist { get; set; }

            public virtual Component IdCmpOnlistNavigation { get; set; }
            public virtual Order IdOrderForcompNavigation { get; set; }
            public int IdComponent { get; set; }
            public string Typecmp { get; set; }
            public string Namecmp { get; set; }
            public int? IdGuaranteecmp { get; set; }
            public int? Manufacturercmp { get; set; }
            public decimal? Pricecmp { get; set; }
            public int? Count { get; set; }
        }
        public static List<OnOrderCmpInfo> GetServicesFor(int id)
        {
            return (from s in Context.db.OnOrderCmps
                    join cp in Context.db.Components on s.IdCmpOnlist equals cp.IdComponent
                    where s.IdOrderForcomp == id
                    select new OnOrderCmpInfo()
                    {
                        IdCmpOnord = s.IdCmpOnord,
                        IdOrderForcomp = s.IdOrderForcomp,
                        IdCmpOnlist = s.IdCmpOnlist,
                        Typecmp = cp.Typecmp,
                        Namecmp = cp.Namecmp,
                        Pricecmp = cp.Pricecmp,
                        Count = cp.Count,
                    }).ToList();
        }
    }
}
