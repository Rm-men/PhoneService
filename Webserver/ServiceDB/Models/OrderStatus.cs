using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
            StoryOrderMoveIdnewstatusNavigations = new HashSet<StoryOrderMove>();
            StoryOrderMoveIdoldstatusNavigations = new HashSet<StoryOrderMove>();
        }

        public string Idos { get; set; }
        public string Descriptionos { get; set; }
        public int? LogicalSequence { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoryOrderMove> StoryOrderMoveIdnewstatusNavigations { get; set; }
        public virtual ICollection<StoryOrderMove> StoryOrderMoveIdoldstatusNavigations { get; set; }
    }
}
