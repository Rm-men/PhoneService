using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Order
    {
        public Order()
        {
            OnOrderCmps = new HashSet<OnOrderCmp>();
            OnOrderSrvs = new HashSet<OnOrderSrv>();
            StoryOrderMoves = new HashSet<StoryOrderMove>();
        }


        public int IdOrder { get; set; }
        public DateTime? Dateord { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int? IdClient { get; set; }
        public int? IdMaster { get; set; }
        public int? IdPhone { get; set; }
        [DefaultValue("add_0")]
        public string IdOrderStatus { get; set; }
        public string Descriptionord { get; set; }
        public string Comments { get; set; }
        public decimal? Priceord { get; set; }
        public bool? Agreement { get; set; }


        public virtual Client IdClientNavigation { get; set; }
        public virtual OrderStatus IdOrderStatusNavigation { get; set; }
        public virtual Phone IdPhoneNavigation { get; set; }
        public virtual ICollection<OnOrderCmp> OnOrderCmps { get; set; }
        public virtual ICollection<OnOrderSrv> OnOrderSrvs { get; set; }
        public virtual ICollection<StoryOrderMove> StoryOrderMoves { get; set; }

    }
}
