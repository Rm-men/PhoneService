﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDB.Entity;

namespace WebServer.Models
{
    public class TeammateModel
    {
        public int ID { get; set; }
        public UserModel User { get; set; }
        public bool IsActive { get; set; }

        public TeammateModel(Teammate teammate)
        {
            ID = teammate.ID;
            User = new UserModel(teammate.User);
            IsActive = false;
        }
    }
}
