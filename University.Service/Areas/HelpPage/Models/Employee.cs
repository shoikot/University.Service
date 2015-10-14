using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Employee:User
    {
        public int EmployeeId { get; set; }

        public List<Event> AssignedEvents { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
