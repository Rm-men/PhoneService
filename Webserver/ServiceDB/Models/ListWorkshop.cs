using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class ListWorkshop
    {
        public ListWorkshop()
        {
            Employees = new HashSet<Employee>();
            StoryOrderMoveIdnewaddressNavigations = new HashSet<StoryOrderMove>();
            StoryOrderMoveIdoldaddressNavigations = new HashSet<StoryOrderMove>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<StoryOrderMove> StoryOrderMoveIdnewaddressNavigations { get; set; }
        public virtual ICollection<StoryOrderMove> StoryOrderMoveIdoldaddressNavigations { get; set; }
    }
}
