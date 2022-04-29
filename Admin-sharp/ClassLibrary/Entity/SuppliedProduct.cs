using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class SuppliedProduct
    {
        public string NameStore { get; set; }
        public int IdSuppply { get; set; }
        public int IdProduct { get; set; }
        public int? Count { get; set; }
        public decimal Price { get; set; }

        public virtual Supply IdSuppplyNavigation { get; set; }
        public virtual Shop NameStoreNavigation { get; set; }
    }
}
