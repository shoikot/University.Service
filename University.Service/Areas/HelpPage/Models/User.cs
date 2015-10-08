using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string Name { get; set; }

        public string CurrentAddress { get; set; }

        public string  ParmanentAddress { get; set; }

        public string NickName { get; set; }

        public List<FileStorage> FileStorages { get; set; }

        public Gender UserGender { get; set; }
    }
}
