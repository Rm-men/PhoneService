using System;
using System.Collections.Generic;

namespace ServiceDB.Models
{
    public partial class EmployeeOfCompany
    {
        public string IdEmployee { get; set; } = null!;
        public string? IdEmploymentContract { get; set; }
        public decimal PassportSerial { get; set; }
        public decimal PassportNubmer { get; set; }
        public string? Adres { get; set; }
        public string? IdEmployeeType { get; set; }
        public string Phone { get; set; } = null!;
        public DateOnly DateOfEmployment { get; set; }
        public string? NameWorkshop { get; set; }
        public string Family { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Workshop? NameWorkshopNavigation { get; set; }
    }
}
