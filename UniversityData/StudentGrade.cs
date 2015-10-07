using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class StudentGrade
    {
        public int StudentGradeId { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int TimeTableId { get; set; }

        public Student Student { get; set; }

        public Grade Grade { get; set; }

        public Course Course { get; set; }

        public TimeTable TimeTable { get; set; }
    }
}
