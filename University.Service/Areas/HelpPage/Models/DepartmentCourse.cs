using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class DepartmentCourse
    {
        public int DepartmentCourseId { get; set; }

        public int DepartmentId { get; set; }

        public int CourseId { get; set; }

        public Department Department { get; set; }

        public Course Course { get; set; }
    }
}
