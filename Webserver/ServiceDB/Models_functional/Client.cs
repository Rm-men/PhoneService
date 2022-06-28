using System;
using System.Collections.Generic;
using System.Linq;


namespace ServiceDB.Models
{
    public partial class Client
    {
        public class ClientInfo
        {
            public int IdClient { get; set; }
            public string Namecl { get; set; }
            public string Family { get; set; }
            public string Patronymic { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Clpassword { get; set; }
            public string FIO { get; set; } //

        }
        public Client(string f, string n, string? p, string pn, string m, string pasw)
        {
            this.Family = f;
            this.Namecl = n;
            if (p != null)
            this.Patronymic = p;
            this.Phone = pn;
            this.Email = m;
            this.Clpassword = pasw;
        }
        // public string FIO { get; set; }
        public static List<ClientInfo> GetClients()
        {
            return (from c in Context.db.Clients
                    select new ClientInfo()
                    {
                        IdClient = c.IdClient,
                        Namecl = c.Namecl,
                        Family = c.Family,
                        Patronymic = c.Patronymic,
                        Phone = c.Phone,
                        Email = c.Email,
                        Clpassword = c.Clpassword,
                        FIO = getFIO(c.Family, c.Namecl, c.Patronymic)
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
        public static Client? GetUserByMail(string login)
        {
            return Context.db.Clients.FirstOrDefault(u => u.Email == login);
        }
        public static Client GeUserForAuth(string login, string password)
        {
            return Context.db.Clients.FirstOrDefault(x => x.Email == login && x.Clpassword == password);
        }
        public bool AddClient()
        {
            try
            {
                Context.db.Clients.Add(this);
                Context.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
