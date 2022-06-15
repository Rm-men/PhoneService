using System;
using System.Collections.Generic;
using System.Linq;
#nullable disable

namespace ServiceDB.Models
{
    public partial class ListSirvice
    {
        public static List<ListSirvice> GetServices()
        {
            return (from s in Context.db.ListSirvices
                    select new ListSirvice()
                    {
                        Id = s.Id,
                        Namesrv = s.Namesrv,
                        Typesrv = s.Typesrv,
                        Descriptionsrv = s.Descriptionsrv,
                        Costsrv = s.Costsrv,
                        Timesrv = s.Timesrv,
                    }).ToList();

        }
    }
}
