using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceDB.Models
{
    public partial class EmployeesView
    {
        public int? Id { get; set; }
        public string IdContract { get; set; }
        public string Paspserial { get; set; }
        public string Paspnumber { get; set; }
        public string Empaddress { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public DateTime? Dateemploymentet { get; set; }
        public int? Workshop { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
