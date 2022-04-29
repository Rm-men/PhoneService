using ClassLibrary.EntityFynctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
    public partial class EmployeeOfCompany: A_Human
    {
        public static EmployeeOfCompany Get(string Login, string Password)
        {
            return Context.Db2.EmployeeOfCompanies.Where(a => a.Login == Login && a.Password == Password).FirstOrDefault();
        }

        public class EmployeeInfo
        {
            public string IdEmployee { get; set; }
            public string IdEmploymentContract { get; set; }
            public decimal PassportSerial { get; set; }
            public decimal PassportNubmer { get; set; }
            public string Adres { get; set; }
            public string EmployeeType { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime DateOfEmployment { get; set; }
            public string NameStore { get; set; }
            public string Family { get; set; }
            public string Name { get; set; }
            public string Patronymic { get; set; }
            //public string Login { get; set; }
            //public string Password { get; set; }


        }
        public static List<EmployeeInfo> GetInfo()
        {
            return (from e in Context.Db2.EmployeeOfCompanies
                    join t in Context.Db2.EmployeeTypes on e.IdEmployeeType equals t.IdEmployeeType
                    select new EmployeeInfo()
                    {
                        IdEmployee = e.IdEmployee,
                        IdEmploymentContract = e.IdEmploymentContract,
                        PassportSerial = e.PassportSerial,
                        PassportNubmer = e.PassportNubmer,
                        Adres = e.Adres,
                        EmployeeType = t.IdEmployeeType,
                        PhoneNumber = e.Phone,
                        DateOfEmployment = e.DateOfEmployment,
                        NameStore = e.NameStore,
                        Family = e.Family,
                        Name = e.Name,
                        Patronymic = e.Patronymic
                    }
                ).ToList();
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
    }
}

