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
    }
}
