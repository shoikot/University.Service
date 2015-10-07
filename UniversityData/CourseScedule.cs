using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class CourseScedule
    {
        public int CourseSceduleId { get; set; }

        public TimeTable TimeTable { get; set; }

        public int TimeTableId { get; set; }
    }
}
