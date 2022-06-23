using ServiceDB;
using ServiceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{

    public class LM_PhoneModels
    {
        public int IdPhoneModel { get; set; }
        public string Namephone { get; set; }
        public string Specifications { get; set; }
        public int? Guarantee { get; set; }
        public string Manufacturer { get; set; }

        public LM_PhoneModels(PhoneModel p)
        {
            IdPhoneModel = p.IdPhoneModel;
            Namephone = p.Namephone;
            Specifications = p.Specifications;
            Guarantee = p.Guarantee;
            // Manufacturer = 
        }

        public LM_PhoneModels()
        {
        }

        public static List<LM_PhoneModels> GetPhoneModels()
        {
            return (from pm in Context.db.PhoneModels
                    join m in Context.db.Manufacturers on pm.Manufacturer equals m.IdManufacturer
                    join g in Context.db.Guarantees on pm.Guarantee equals g.IdGuarantee
                    select new LM_PhoneModels()
                    {
                        IdPhoneModel = pm.IdPhoneModel,
                        Namephone = pm.Namephone,
                        Specifications = pm.Specifications,
                        Guarantee = g.Period,
                        Manufacturer = m.Name,
                    }).ToList(); ;
        }

    }
    public class LM_Adress
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public LM_Adress(ListWorkshop w) { 
            Id = w.Id;
            Address = w.Address;
            Description = w.Description;
            Type = w.Type;
        }
        public static List<LM_Adress> GetAdresses()
        {
            List<LM_Adress> adresses = new List<LM_Adress>();
            foreach (ListWorkshop lw in ListWorkshop.GetPickupAddress())
            {
                adresses.Add(new LM_Adress(lw));
            }
            return adresses;
             
        }
    }
    public class LM_OrderStoryMove
    {
        public int? Idorder { get; set; }
        // public int? Idhuman { get; set; }
        public string? FIOm { get; set; }

        public string? Idoldstatus { get; set; }
        public string? OldstatusDesc { get; set; }

        public string? Idnewstatus { get; set; }
        public string? NewstatusDesc { get; set; }

        public int? Idoldaddress { get; set; }
        public int? Idnewaddress { get; set; }
        public DateTime? Somdate { get; set; }

        public LM_OrderStoryMove()
        {
        }
        public static List<LM_OrderStoryMove> GetOrderMoves(int IdOrder)
        {
            return (from o in Context.db.StoryOrderMoves
                   join e in Context.db.Employees on o.Idhuman equals e.Id
                   join st in Context.db.OrderStatuses on o.Idnewstatus equals st.Idos
                   join ord in Context.db.Orders on o.Idorder equals ord.IdOrder
                   where o.Idorder == IdOrder
                    select new LM_OrderStoryMove()
                   {
                       // Idhuman = o.Idhuman,
                       Idorder = o.Idorder,
                       // Idoldstatus = o.Idoldstatus,
                       OldstatusDesc = st.Descriptionos,
                       // Idnewstatus = o.Idnewstatus,
                       NewstatusDesc = st.Descriptionos,
                       // Idoldaddress = o.Idoldaddress,
                       // Idnewaddress = o.Idnewaddress,
                       Somdate = o.Somdate,
                       FIOm = Employee.getFIO(e.Family, e.Name, e.Patronymic),
                   }).ToList(); ;

        }
    }
}
