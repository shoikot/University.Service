using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class Event
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string  EventLocation { get; set; }

        public string EventDetail { get; set; }

        public int EventTimeTableId { get; set; }
        public List<Employee> EventArrengers { get; set; }
        public TimeTable EventTime { get; set; }
    }
}
