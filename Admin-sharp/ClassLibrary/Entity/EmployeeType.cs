using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            EmployeeOfCompanies = new HashSet<EmployeeOfCompany>();
        }

        public string IdEmployeeType { get; set; }
        public string ResponsibleDescription { get; set; }

        public virtual ICollection<EmployeeOfCompany> EmployeeOfCompanies { get; set; }
    }
}
