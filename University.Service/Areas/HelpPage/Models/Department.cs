using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Title { get; set; }

        public int FileStorageId { get; set; }
        public List<Teacher> Teachers { get; set; }

        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }

        public List<Employee> Employees { get; set; }

        public FileStorage FileStorage { get; set; }

        public List<CourseScedule> CourseScedules { get; set; }

        public List<Event> Events { get; set; }

    }
}
