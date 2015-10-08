using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class News
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public string NewsSource { get; set; }
    }
}
