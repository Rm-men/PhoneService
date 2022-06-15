using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDB.Entity;

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

        public ClientModel(User user)
        {
            //IdClient = user.IdClient;
            //Namecl = user.Namecl;
            //Family = user.Family;
            //Patronymic = user. ;
            //Phone = user. ;
            //Email = user. ;
            //Clpassword = this.Clpassword;
    }

    }
}
