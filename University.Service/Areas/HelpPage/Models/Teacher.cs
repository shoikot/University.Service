﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Teacher:User
    {
        public int TeacherId { get; set; }

        public int YearOfExperience { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<Course> Courses { get; set; }

    }
}
