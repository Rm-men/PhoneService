using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class PushareAgreement
    {
        public PushareAgreement()
        {
            PositionInOrders = new HashSet<PositionInOrder>();
        }

        public int IdPushareAgreement { get; set; }
        public string NameStore { get; set; }
        public int? IdClient { get; set; }
        public decimal AllCost { get; set; }
        public DateTime PushareAgreementDate { get; set; }
        public int? IdOrder { get; set; }
        public bool? Paid { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Order IdOrderNavigation { get; set; }
        public virtual Shop NameStoreNavigation { get; set; }
        public virtual ICollection<PositionInOrder> PositionInOrders { get; set; }
    }
}
