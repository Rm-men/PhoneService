using System;
using System.Collections.Generic;
using System.Linq;


#nullable disable

namespace ServiceDB.Models
{
    public partial class Client
    {
        // public string FIO { get; set; }
        public static List<Client> GetClients()
        {
            return (from c in Context.db.Clients
                    select new Client()
                    {
                        IdClient = c.IdClient,
                        Namecl = c.Namecl,
                        Family = c.Family,
                        Patronymic = c.Patronymic,
                        Phone = c.Phone,
                        Email = c.Email,
                        Clpassword = c.Clpassword,
                        // FIO = getFIO(c.Family, c.Namecl, c.Patronymic)
                    }).ToList();
        }
        public virtual string getFIO()
        {
            string fio = $"{Family} {Namecl.Substring(0, 1)}.";
            if (Patronymic != "") fio += $"{Family.Substring(0, 1)}.";
            return fio;
        }
        public static string getFIO(string f, string n, string p)
        {
            string fio = $"{f} {n.Substring(0, 1)}.";
            if (p != "") fio += $"{f.Substring(0, 1)}.";
            return fio;
        }
        public static Client? GetUserByLogin(string login)
        {
            return Context.db.Clients.FirstOrDefault(u => u.Email == login);
        }
        public static Client GeUserForAuth(string login, string password)
        {
            return Context.db.Clients.FirstOrDefault(x => x.Email == login && x.Clpassword == password);
        }
    }
}
