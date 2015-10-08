using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public string RoleName { get; set; }//use enum?

        public List<Employee> Employees { get; set; }

        public List<Teacher> Teachers { get; set; }
    }


}
