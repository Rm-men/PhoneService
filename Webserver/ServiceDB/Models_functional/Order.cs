using System;
using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace ServiceDB.Models
{
    public partial class Order
    {
        public static List<Order> GetOrders()
        {
            return (from c in Context.db.Orders
                    select new Order()
                    {

                        IdClient = c.IdClient,
                        Phonenumber = c.Phonenumber,
                        IdOrder = c.IdOrder,
                        Dateord = c.Dateord,
                        Comments = c.Comments,
                        Descriptionord = c.Descriptionord,
                        IdMaster = c.IdMaster,
                        IdOrderStatus = c.IdOrderStatus,
                        IdPhone = c.IdPhone,
                        Address = c.Address,
                        Priceord = c.Priceord,
                        Agreement = c.Agreement,
                        
                    }).ToList();
        }
    }
}
