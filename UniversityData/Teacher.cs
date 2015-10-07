using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class Teacher:User
    {
        public int TeacherId { get; set; }

        public int YearOfExperience { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public List<Course> Courses { get; set; }

    }
}
