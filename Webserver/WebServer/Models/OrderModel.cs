using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class OrderModel
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
        public bool? Agreement { get; set; }
    }
}
