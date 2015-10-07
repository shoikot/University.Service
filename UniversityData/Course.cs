using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public CourseType CourseType { get; set; }

        public List<Teacher> Teachers { get; set; }


    }

    public enum CourseType
    {
        Theory,
        Laborotory
    }
}
