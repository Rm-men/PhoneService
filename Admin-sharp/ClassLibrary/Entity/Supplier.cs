using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplies = new HashSet<Supply>();
        }

        public string IdSupplier { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
