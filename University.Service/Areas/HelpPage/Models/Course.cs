using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public string CourseCode { get; set; }

        public CourseType CourseType { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Attendence> Attendences { get; set; }

        public List<Student> Students { get; set; }
    }

    public enum CourseType
    {
        Theory,
        Laborotory
    }
}
