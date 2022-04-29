using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class EmployeeOfCompany
    {
        public string IdEmployee { get; set; }
        public string IdEmploymentContract { get; set; }
        public decimal PassportSerial { get; set; }
        public decimal PassportNubmer { get; set; }
        public string Adres { get; set; }
        public string IdEmployeeType { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public string NameStore { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual EmployeeType IdEmployeeTypeNavigation { get; set; }
        public virtual Shop NameStoreNavigation { get; set; }
    }
}
