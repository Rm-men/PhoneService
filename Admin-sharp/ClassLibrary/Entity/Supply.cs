using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Supply
    {
        public Supply()
        {
            SuppliedProducts = new HashSet<SuppliedProduct>();
        }

        public int IdSupply { get; set; }
        public int? IdSupplyOrder { get; set; }
        public string IdSupplier { get; set; }
        public DateTime DateSupply { get; set; }
        public decimal PriceSupply { get; set; }
        public string DescriptionSupply { get; set; }

        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual SupplyOrder IdSupplyOrderNavigation { get; set; }
        public virtual ICollection<SuppliedProduct> SuppliedProducts { get; set; }
    }
}
