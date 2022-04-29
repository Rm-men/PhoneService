using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class Client
    {
        public static List<ClientInfo> GetInfo() 
        {
            return (from c in Context.Db2.Clients
                    select new ClientInfo()
                    {
                        IdClient = c.IdClient,
                        Family = c.Family,
                        Name = c.Name,
                        Patronymic = c.Patronymic,
                        Phone = c.Phone,
                        Email = c.Email
                    }).ToList();
        }
        public class ClientInfo
        {
            public int IdClient { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            public string Patronymic { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
        public static Client FindClient(string p, string m)
        {
            if (p != "")
                return Context.Db2.Clients.Where(a => a.Phone == p).FirstOrDefault();
            else
                return Context.Db2.Clients.Where(a => a.Email == m).FirstOrDefault();
        }
    }
}


