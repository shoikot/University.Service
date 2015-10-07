using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityData
{
    public class Task
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public int EmployeeId { get; set; }
        public List<Employee> Assinee { get; set; }
        public int TimeTableId { get; set; }

        public TimeTable TimeTable { get; set; }
    }
}
