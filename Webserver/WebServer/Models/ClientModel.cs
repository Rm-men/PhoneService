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
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Clpassword { get; set; }

        public ClientModel(Client user)
        {
            IdClient = user.IdClient;
            Family = user.Family;
            Namecl = user.Namecl;
            Patronymic = user.Patronymic;
            Email = user.Email;
            Phone = user.Phone;
        }
    }
}
