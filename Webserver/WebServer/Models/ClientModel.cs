using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDB.Models;

namespace WebServer.Models
{
    public class ClientModel
    {
        public int IdClient { get; set; }
        public string Namecl { get; set; }
        public string Family { get; set; }
        public string? Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Clpassword { get; set; }

        public ClientModel(Client user)
        {
            IdClient = user.IdClient;
            Family = user.Family;
            Namecl = user.Namecl;
            Patronymic = user.Patronymic;
            Phone = user.Phone;
            Email = user.Email;
        }
        public ClientModel(string f, string n, string? p, string pn, string m, string pasw)
        {
            this.Family = f;
            this.Namecl = n;
            this.Patronymic = p;
            this.Phone = pn;
            this.Email = m;
            this.Clpassword = pasw;
        }
    }
}
