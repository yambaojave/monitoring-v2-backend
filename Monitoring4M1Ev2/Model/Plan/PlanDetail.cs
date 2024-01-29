using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Plan
{
    public class PlanDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanDetailId { get; set; }
        public string Operator { get; set; }
        public string Process { get; set; }
        public string ControlNumber { get; set; }
        public string Machines { get; set; }
        public string Condition { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PlanHeaderId { get; set; }
        public PlanHeader PlanHeader { get; set; }
    }

    public class PlanDetailDto
    {
        public string Operator { get; set; }
        public string Condition { get; set; }
        public string Process { get; set; }
        public string ControlNumber { get; set; }
        public string Machines { get; set; }
        public int PlanHeaderId { get; set; }
    }

}
