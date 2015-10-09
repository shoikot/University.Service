using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Service.Areas.HelpPage.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public decimal GradePoint { get; set; }

        public string GradeSymbol { get; set; }


        public List<University.Service.Areas.HelpPage.Models.Result> Results { get; set; }
    }
}
