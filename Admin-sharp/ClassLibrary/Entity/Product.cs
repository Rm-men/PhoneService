using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Product
    {
        public string type;
        public Product()
        {
            Components = new HashSet<Component>();
            PhoneModels = new HashSet<PhoneModel>();
            PositionInOrders = new HashSet<PositionInOrder>();
            this.type = this.Name;
        }

        public string IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Counts { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<PhoneModel> PhoneModels { get; set; }
        public virtual ICollection<PositionInOrder> PositionInOrders { get; set; }
    }
}
