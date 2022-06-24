using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OnOrderSrv
    {
        public class OnOrderSrvInfo
        {
            public int IdSrvOnord { get; set; }
            public int? IdOrderForservice { get; set; }
            public int? IdSrvOnlist { get; set; }
            public int Id { get; set; }
            public string Namesrv { get; set; }
            public string Typesrv { get; set; }
            public string Descriptionsrv { get; set; }
            public decimal? Costsrv { get; set; }
            public string Timesrv { get; set; }


            public virtual Order IdOrderForserviceNavigation { get; set; }
            public virtual ListSirvice IdSrvOnlistNavigation { get; set; }

        }
        public static List<OnOrderSrvInfo> GetServicesFor(int id)
        {
            return (from s in Context.db.OnOrderSrvs
                    join ls in Context.db.ListSirvices on s.IdSrvOnlist equals ls.Id
                    where s.IdOrderForservice == id
                    select new OnOrderSrvInfo()
                    {
                        IdSrvOnord = s.IdSrvOnord,
                        IdOrderForservice = s.IdOrderForservice,
                        IdSrvOnlist = s.IdSrvOnlist,
                        Id = ls.Id,
                        Namesrv = ls.Namesrv,
                        Typesrv = ls.Typesrv,
                        Descriptionsrv = ls.Descriptionsrv,
                        Timesrv = ls.Timesrv,
                        Costsrv = ls.Costsrv,
                    }).ToList();
        }

    }
}
