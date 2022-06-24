using System;
using System.Collections.Generic;
using System.Linq;
using static ServiceDB.Models.Employee;


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
            this.IdMaster = 0;
            this.Descriptionord = Descriptionord;
            this.Dateord = DateTime.Now;
            this.IdOrderStatus = "add_0";
            this.Comments = "";
        }
        public static Order GetOrderOriginal(int id)
        {
            var orders = new List<Order>(from o in Context.db.Orders
                                             where o.IdOrder == id
                                             select new Order()
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
                                                 Agreement = o.Agreement.Value,
                                                 Diagnostic = o.Diagnostic,
                                                 Payed = o.Payed,
                                             }).ToList();
            return (orders.FirstOrDefault());
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
            public string?  Manufacturer { get; set; }

            public bool ? Agreement { get; set; }
            public string AgreementText { get; set; }
            public string FIOCl { get; set; } //
            public string FIOm { get; set; } //
            public string PhoneModel { get; set; } //
            public string Status { get; set; } //
            public string Diagnostic { get; set; }
            public bool? Payed { get; set; }

        }
        public static List<OrderInfo> GetOrders()
        {
            var orders = new List<OrderInfo>(from o in Context.db.Orders
                                             join c in Context.db.Clients on o.IdClient equals c.IdClient
                                             join pm in Context.db.PhoneModels on o.IdPhone equals pm.IdPhoneModel
                                             join m in Context.db.Manufacturers on pm.Manufacturer equals m.IdManufacturer
                                             /*                                             join m in Context.db.Employees on o.IdMaster equals m.Id
                                             */
                                             join st in Context.db.OrderStatuses on o.IdOrderStatus equals st.Idos
                                             select new OrderInfo()
                                             {
                                                 Manufacturer = m.Name,
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
                                                 Diagnostic = o.Diagnostic,
                                                 Payed = o.Payed,
                                                 FIOCl = GetFIO(c.Family, c.Namecl, c.Patronymic),
                                                 /*                                                 FIOm = getFIO(m.Family, m.Name, m.Patronymic),
                                                 */
                                                 Status = st.Descriptionos,
                                             }).ToList();
            var emps = new List<Employee.EmployeeInfo>(GetEmployees());
            foreach (OrderInfo ord in orders)
            {
                if (ord.IdMaster != null)
                    foreach (EmployeeInfo emp in emps)
                        if (ord.IdMaster == emp.Id)
                        {
                            ord.FIOm = emp.FIO;
                            break;
                        }
                        else ord.FIOm = "Не назначен";
            }

            return (orders);
        }

        public static List<OrderInfo> GetOrdersInfoForUser(int id)
        {
            List<OrderInfo> ordersForUser = new List<OrderInfo>();
            foreach (OrderInfo ord in GetOrders())
            {
                if (ord.IdClient == id)
                    ordersForUser.Add(ord);
            }
            return ordersForUser;
        }
        public static string GetFIO(string f, string n, string p)
        {
            string fio = $"{f} {n.Substring(0, 1)}.";
            if (p != "") fio += $"{f.Substring(0, 1)}.";
            return fio;
        }
        public static Order GetOrder(int IdOrder)
        {
            Order ord = Context.db.Orders.Where(a => a.IdOrder == IdOrder).FirstOrDefault();
            return ord;
        }
        public bool SetAgree(bool agree)
        {
            try
            {
                Order NewOrder = GetOrderOriginal(this.IdOrder);
                Order OldOrder = GetOrder(this.IdOrder);
                {
                    OldOrder.IdMaster = NewOrder.IdMaster;
                    OldOrder.IdOrderStatus = NewOrder.IdOrderStatus;
                    OldOrder.Descriptionord = NewOrder.Descriptionord;
                    OldOrder.Priceord = NewOrder.Priceord;
                }
                this.IdOrderStatus = (agree) ? ("waiting_1") : ("waiting_2");
                this.Agreement = agree;
                if (!agree)
                    this.Payed = false;
                // Context.db.Attach(this).DetectChanges();
                // Context.db.Entry(this).CurrentValues.SetValues(this);
                // Context.db.Entry(this).DetectChanges();
                Context.db.Update(this);
                Context.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetPay()
        {
            try
            {
                this.Payed = true;
                Context.db.Update(this);
                Context.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
