using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Output
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OutputId { get; set; }
        public string TimeRange { get; set; }
        public int Plan { get; set; }
        public int Actual { get; set; }
        public int Difference { get; set; }
        public int UserInput { get; set; }
        public bool Updated { get; set; }
        public string Remarks { get; set; }
        public DateTime UpdateDate { get; set; }
        public int HeaderId { get; set; }
    }

    public class OutputDto
    {
        public string TimeRange { get; set; }
        public int Plan { get; set; }
        public int Actual { get; set; }
        public int Difference { get; set; }
        public int HeaderId { get; set; }
        public bool Updated { get; set; }
    }

    public class OutputCompute
    {
        public int OutputId { get; set; }
        public int HeaderId { get; set; }
        public int Actual { get; set; }
        public string Remarks { get; set; }
    }
}
