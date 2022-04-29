using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class SupplyOrder
    {
        public SupplyOrder()
        {
            Supplies = new HashSet<Supply>();
        }

        public int IdSupplyOrder { get; set; }
        public DateTime DateSuplOrder { get; set; }
        public string IdEmployee { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
