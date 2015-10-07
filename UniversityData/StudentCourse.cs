using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
