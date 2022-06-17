using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OrderStatus
    {
        public static int id = 0;
        public class ListOrderStatus
        {
            public int Id;
            public string Description { get; set; }
        }
        public static List<ListOrderStatus> GetOrderStatus()
        {
            return (from o in Context.db.OrderStatuses
                    select new ListOrderStatus()
                    {
                        Id = id,
                        Description = o.Descriptionos,
                    }).ToList();
        }

        public static implicit operator string(OrderStatus v)
        {
            throw new NotImplementedException();
        }
    }
}
