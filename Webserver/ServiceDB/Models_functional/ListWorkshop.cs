using System;
using System.Linq;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class ListWorkshop
    {
        public static List<ListWorkshop> GetAllAddress()
        {
            return (from o in Context.db.ListWorkshops
                    select new ListWorkshop()
                    {
                        Address = o.Address,
                        Id = o.Id,
                        Type = o.Type,
                        Description = o.Description,
                    }).ToList();
        }
        public static List<ListWorkshop> GetPickupAddress()
        {
            List<ListWorkshop> list = new List<ListWorkshop>();
            foreach (ListWorkshop lw in GetAllAddress())
            {
                if (lw.Type == "Пункт приема") list.Add(lw);
            }
            return list;
        }
    }
}
