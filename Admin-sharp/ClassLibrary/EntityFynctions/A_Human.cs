using ClassLibrary.EntityFynctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class A_Human
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }

        public A_Human()
        {

        }

        public string GetInfo()
        {
            string fullName = $"{Family} {Name}";
            if (Patronymic != null) fullName += $" {Patronymic}";
            return fullName;
        }

    }
}
