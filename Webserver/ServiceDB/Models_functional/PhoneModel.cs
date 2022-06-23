using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace ServiceDB.Models
{
    public partial class PhoneModel
    {
        public static PhoneModel getPhoneModel(string Namephone)
        {
          return Context.db.PhoneModels.Where(a => a.Namephone == Namephone).FirstOrDefault();

        }

    }
}
