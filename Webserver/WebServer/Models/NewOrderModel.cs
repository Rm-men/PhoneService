using ServiceDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class NewOrderModel
    {
        public string Phonenumber { get; set; }
        public string Address { get; set; }
        public int? IdPhone { get; set; }
        public string Descriptionord { get; set; }
        public string Email { get; set; }
        public NewOrderModel()
        {
        }

        public NewOrderModel(Order user)
        {
            Phonenumber = user.Phonenumber;
            Address = user.Address;
            IdPhone = user.IdPhone;
            Descriptionord = user.Descriptionord;
        }
    }
}
