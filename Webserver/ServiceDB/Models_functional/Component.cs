using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Component
    {
        public class ListComponentType {
            public string Type { get; set; }
        }
        public static List<ListComponentType> GetComponentsTypes()
        {
            return (from o in Context.db.Components
                    select new ListComponentType()
                    {
                       Type = o.Typecmp
                    }).ToList();
        }
        public static List<string> GetComponentsTypesList(List<ListComponentType> list)
        {
            List<string> listT = new List<string>();
            foreach (ListComponentType cp in list)
            {
                listT.Add(cp.Type);
            }
            return listT;
        }
        public static List<string> GetComponentsTypesList()
        {
            List<ListComponentType> list = GetComponentsTypes();
            List<string> listT = new List<string>();
            foreach (ListComponentType cp in list)
            {
                listT.Add(cp.Type);
            }
            return listT;
        }
        public class ComponentInfo
        {
            public int IdComponent { get; set; }
            public string Typecmp { get; set; }
            public string Namecmp { get; set; }
            public int? IdGuaranteecmp { get; set; }
            public int? Guaranteecmp_period { get; set; } // 
            public int Manufacturercmp { get; set; }
            public string Manufacturercmp_name { get; set; } // 
            public decimal? Pricecmp { get; set; }
            public int? Count { get; set; }
        }
        public static List<ComponentInfo> GetComponents()
        {
            return (from c in Context.db.Components
                    join m in Context.db.Manufacturers on c.Manufacturercmp equals m.IdManufacturer
                    join gar in Context.db.Guarantees on c.IdGuaranteecmp equals gar.IdGuarantee
                    select new ComponentInfo()
                    {
                        IdComponent = c.IdComponent,
                        Typecmp = c.Typecmp,
                        Namecmp = c.Namecmp,
                        IdGuaranteecmp = c.IdGuaranteecmp,
                        Manufacturercmp = (int)c.Manufacturercmp,
                        Pricecmp = c.Pricecmp,
                        Count = c.Count,
                        Guaranteecmp_period = gar.Period,
                        Manufacturercmp_name = m.Name
                    }).ToList();
        }
        public static Component GetComponent(int IdProduct)
        {
            return Context.db.Components.Where(a => a.IdComponent == IdProduct).FirstOrDefault();
        }
    }
}
