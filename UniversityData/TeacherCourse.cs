using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public int TimeTableId { get; set; }
        public TimeTable TimeTable { get; set; }
        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
