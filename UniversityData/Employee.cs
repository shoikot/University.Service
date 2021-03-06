﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class Employee:User
    {
        public int EmployeeId { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public List<Event> AssignedEvents { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
