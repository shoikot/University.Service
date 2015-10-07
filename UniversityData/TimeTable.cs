using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class TimeTable
    {
        public int TimeTableId { get; set; }

        public DateTime AssigningDate { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime Duration { get; set; }

        public DateTime Year { get; set; }

        public DateTime Date { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

    }

    public enum DayOfWeek {
           Saturday,
           Sunday,
           Monday,
           Tuesday,
           Wednesday,
           Thursday,
           Friday

    }
}
