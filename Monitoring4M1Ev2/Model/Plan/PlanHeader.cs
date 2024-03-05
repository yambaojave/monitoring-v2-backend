using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Plan
{
    public class PlanHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanHeaderId { get; set; }
        public string Model { get; set; }
        public int Shift { get; set; }
        public string Line { get; set; }
        public string Type { get; set; }
        public bool IsUsed { get; set; }
        public DateTime UsedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime PlanDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<PlanDetail> PlanDetails { get; set; }
    }

    public class PlanHeaderDto
    {
        public string Model { get; set; }
        public int Shift { get; set; }
        public string Line { get; set; }
        public DateTime PlanDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
