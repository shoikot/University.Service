﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public string RoleName { get; set; }//use enum?

        public List<User> Users { get; set; }
    }


}
