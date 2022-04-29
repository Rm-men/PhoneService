using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class Order
    {
        public static List<Info> GetInfo()
        {
            return (from o in Context.Db2.Orders
                    join s in Context.Db2.OrderStatuses on o.IdOrderStatus equals s.IdOrderStatus
                    join p in Context.Db2.PushareAgreements on o.IdOrder equals p.IdOrder
                    select new Info()
                    {
                        IdOrder = o.IdOrder,
                        OrderDate = o.OrderDate,
                        PhoneNumber = o.PhoneNumber,
                        Address = o.Address,
                        IdClient = o.IdClient,
                        IdOrderStatus = s.DescriptionOrderStatus,
                        Cost = (decimal)p.AllCost
                    }).ToList();
        }
        public class Info
        {
            public int IdOrder { get; set; }
            public DateTime OrderDate { get; set; }
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public int? IdClient { get; set; }
            public string IdOrderStatus { get; set; }
            public decimal Cost { get; set; }

        }
        public static Order GetOrder(int Id)
        {
            return Context.Db2.Orders.Where(a => a.IdOrder == Id).FirstOrDefault();
        }
        public static PushareAgreement GetPa(int Id)
        {
            return Context.Db2.PushareAgreements.Where(a => a.IdOrder == Id).FirstOrDefault();
        }
        public PushareAgreement GetPa()
        {
            return Context.Db2.PushareAgreements.Where(a => a.IdOrder == IdOrder).FirstOrDefault();
        }
        public static List<Order> GetOrders()
        {
            return (from o in Context.Db2.Orders
                    select new Order()
                    {
                        IdOrder = o.IdOrder,
                        OrderDate = o.OrderDate,
                        PhoneNumber = o.PhoneNumber,
                        Address = o.Address,
                        IdClient = o.IdClient,
                        IdOrderStatus = o.IdOrderStatus
                    }).ToList();
        }
    }
}
