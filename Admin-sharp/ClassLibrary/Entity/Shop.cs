using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class Shop
    {
        public Shop()
        {
            EmployeeOfCompanies = new HashSet<EmployeeOfCompany>();
            PushareAgreements = new HashSet<PushareAgreement>();
            SuppliedProducts = new HashSet<SuppliedProduct>();
        }

        public string NameStore { get; set; }
        public string Address { get; set; }

        public virtual ICollection<EmployeeOfCompany> EmployeeOfCompanies { get; set; }
        public virtual ICollection<PushareAgreement> PushareAgreements { get; set; }
        public virtual ICollection<SuppliedProduct> SuppliedProducts { get; set; }
    }
}
