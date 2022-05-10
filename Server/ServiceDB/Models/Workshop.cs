using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class Workshop
    {
        public Workshop()
        {
            EmployeeOfCompanies = new HashSet<EmployeeOfCompany>();
        }

        public string NameWorkshop { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<EmployeeOfCompany> EmployeeOfCompanies { get; set; }
    }
}
