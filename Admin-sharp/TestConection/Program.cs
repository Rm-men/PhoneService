using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClassLibrary;
using System.Collections.Generic;


#nullable disable

namespace TestConection
{
    class Program
    {
        private static ApplicationContext db2 = Context.Db2;

        public static void View_al()
        {
            List<Client> cl_sp = db2.Clients.ToList();
            Console.WriteLine("Список объектов:");
            //Client cl1 = new Client { Email = "1gagaga@mail.da", Family = "Пупкин", Name = "Вася" };
            //cl_sp.Add(cl1);
            //db.Clients.Add(cl1);
            //cl_sp[0].Name = "Y";
            foreach (Client c in cl_sp)
            {
                Console.WriteLine($"{c.Name}");
            }
            Context.Db2.SaveChanges();
        }
        public static void Login()
        {
            Console.WriteLine("Введите логин:");
            string log = Console.ReadLine();
            Console.WriteLine("Введите пароль:");
            string pasw = Console.ReadLine();
            EmployeeOfCompany employee = EmployeeOfCompany.Get(log, pasw);
            if (employee != null)
            {
                Console.WriteLine($"Вы - " + employee.Name);
            }
            else Console.WriteLine($"Введен не правильный логин или пароль");
        }
        public static void View_products()
        {
            List<Product> pr = db2.Products.ToList();
            Console.WriteLine("Список продуктов:");
            foreach (Product prd in pr)
            {
                Console.WriteLine($"{prd.IdProduct}, {prd.Name}, {prd.Price}, {prd.Counts}");
            }
        }
        public static void AddManuf()
        {
            List<Manufacturer> pr = db2.Manufacturers.ToList();
            Console.WriteLine("Список производителей:");
            foreach (Manufacturer prd in pr)
            {
                Console.WriteLine($"{prd.IdManufacturer}, {prd.Name}");
            }
            Console.Write("Ид: ");
            string id = Console.ReadLine();
            Console.Write("Имя: ");
            string Name = Console.ReadLine();
            db2.Manufacturers.Add(new Manufacturer { IdManufacturer = id, Name = Name });
            Context.Db2.SaveChanges();
        }
        static void Main(string[] args)
        {
            AddManuf();
            Console.ReadKey();
        }
    }
}
