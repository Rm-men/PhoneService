using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace ServiceDB.Models
{
    public partial class Employee
    {
        /*        public string FIO { get; set; }*/
        public class EmployeeInfo
        {
            public int Id { get; set; }
            public string IdContract { get; set; }
            public string Paspserial { get; set; }
            public string Paspnumber { get; set; }
            public string Empaddress { get; set; }
            public string Type { get; set; }
            public string Phone { get; set; }
            public DateTime Dateemploymentet { get; set; }
            public int Workshop { get; set; }
            public string Family { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string FIO { get; set; }

        }

        public static Employee Get(string Login, string Password)
        {
            return Context.db.Employees.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
        }
        public static string GetHash(string input)
        {
            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));

            }
            return sBuilder.ToString();
        }
        public virtual string getFIO()
        {
            string fio = $"{Family} {Name.Substring(0, 1)}.";
            if (Patronymic != "") fio += $"{Family.Substring(0, 1)}.";
            return fio;
        }
        public static string getFIO(string f, string n, string p)
        {
            string fio = $"{f} {n.Substring(0, 1)}.";
            if (p != "") fio += $"{f.Substring(0, 1)}.";
            return fio;
        }
        public static List<EmployeeInfo> GetEmployees()
        {
            return (from e in Context.db.Employees
                    select new EmployeeInfo()
                    {
                        Id = e.Id,
                        Paspnumber = e.Paspnumber,
                        Paspserial = e.Paspserial,
                        Empaddress = e.Empaddress,
                        Type = e.Type,
                        Phone = e.Phone,
                        Dateemploymentet = e.Dateemploymentet,
                        Workshop = e.Workshop,
                        Family = e.Family,
                        Name = e.Name,
                        Patronymic = e.Patronymic,
                        Login = e.Login,
                        Password = e.Password,
                        IdContract = e.IdContract,
                        FIO = getFIO(e.Family, e.Name, e.Patronymic),
                    }).ToList();
        }
    }
}
