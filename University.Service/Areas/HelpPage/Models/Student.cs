using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Student:User
    {
        public int StudentId { get; set; }

        public int RollNo { get; set; }

        public int DepartmentId { get; set; }

        public List<StudentCourse> Courses { get; set; }

        public Department Department { get; set; }

        public List<Attendence> Attendences { get; set; }
    }


    public enum Gender {
        Male,
        Female
    }
}
