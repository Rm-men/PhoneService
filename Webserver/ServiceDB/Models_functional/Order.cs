using System;
using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace ServiceDB.Models
{
    public partial class Order
    {
/*        public int IdOrder { get; set; }
        public DateTime? Dateord { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int? IdClient { get; set; }
        public int? IdMaster { get; set; }
        public int? IdPhone { get; set; }
        public string IdOrderStatus { get; set; }
        public string Descriptionord { get; set; }
        public string Comments { get; set; }
        public decimal? Priceord { get; set; }
        public bool? Agreement { get; set; }*/

        public Order(string Phonenumber, string Address, int IdClient, int? IdPhone, string Descriptionord)
        {
            this.Phonenumber = Phonenumber;
            this.Address = Address;
            this.IdClient = IdClient;
            this.IdPhone = IdPhone;
            this.Descriptionord = Descriptionord;
            this.Dateord = DateTime.Now;
            this.IdOrderStatus = "add_0";
        }
        public class OrderInfo
        {
            public int IdOrder { get; set; }
            public DateTime? Dateord { get; set; }
            public string Phonenumber { get; set; }
            public string Address { get; set; }
            public int? IdClient { get; set; }
            public int? IdMaster { get; set; }
            public int? IdPhone { get; set; }
            public string IdOrderStatus { get; set; }
            public string Descriptionord { get; set; }
            public string Comments { get; set; }
            public decimal? Priceord { get; set; }
            public bool Agreement { get; set; }
            public string AgreementText { get; set; }
            public string FIOCl { get; set; } //
            public string FIOm { get; set; } //
            public string PhoneModel { get; set; } //
            public string Status { get; set; } //

        }
        public static List<OrderInfo> GetOrders()
        {
            return (from o in Context.db.Orders
                    join c in Context.db.Clients on o.IdClient equals c.IdClient
                    join pm in Context.db.PhoneModels on o.IdPhone equals pm.IdPhoneModel
                    join m in Context.db.Employees on o.IdMaster equals m.Id
                    join st in Context.db.OrderStatuses on o.IdOrderStatus equals st.Idos
                    select new OrderInfo()
                    {
                        IdClient = o.IdClient,
                        Phonenumber = o.Phonenumber,
                        IdOrder = o.IdOrder,
                        Dateord = o.Dateord,
                        Comments = o.Comments,
                        Descriptionord = o.Descriptionord,
                        IdMaster = o.IdMaster,
                        IdOrderStatus = o.IdOrderStatus,
                        IdPhone = o.IdPhone,
                        Address = o.Address,
                        Priceord = o.Priceord,
                        Agreement = (bool)o.Agreement,
                        AgreementText = (bool)o.Agreement ? ("*") : (""),
                        PhoneModel = pm.Namephone, 
                        FIOCl = getFIO(c.Family, c.Namecl, c.Patronymic),
                        FIOm = getFIO(m.Family, m.Name, m.Patronymic),
                        Status = st.Descriptionos,
                    }).ToList();
        }
        public static List<OrderInfo> GetOrdersForUser(string mail)
        {
            return (from o in Context.db.Orders
                    join c in Context.db.Clients on o.IdClient equals c.IdClient
                    join pm in Context.db.PhoneModels on o.IdPhone equals pm.IdPhoneModel
                    join m in Context.db.Employees on o.IdMaster equals m.Id
                    join st in Context.db.OrderStatuses on o.IdOrderStatus equals st.Idos
                    // where c.Email == mail
                    select new OrderInfo()
                    {
                        IdClient = o.IdClient,
                        Phonenumber = o.Phonenumber,
                        IdOrder = o.IdOrder,
                        Dateord = o.Dateord,
                        Comments = o.Comments,
                        Descriptionord = o.Descriptionord,
                        IdMaster = o.IdMaster,
                        IdOrderStatus = o.IdOrderStatus,
                        IdPhone = o.IdPhone,
                        Address = o.Address,
                        Priceord = o.Priceord,
                        Agreement = (bool)o.Agreement,
                        AgreementText = (bool)o.Agreement ? ("*") : (""),
                        PhoneModel = pm.Namephone,
                        FIOCl = getFIO(c.Family, c.Namecl, c.Patronymic),
                        FIOm = getFIO(m.Family, m.Name, m.Patronymic),
                        Status = st.Descriptionos,
                    }).ToList();
        }

        public static string getFIO(string f, string n, string p)
        {
            string fio = $"{f} {n.Substring(0, 1)}.";
            if (p != "") fio += $"{f.Substring(0, 1)}.";
            return fio;
        }
        public bool AddOrder()
        {
            try
            {
                Context.db.Orders.Add(this);
                Context.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
