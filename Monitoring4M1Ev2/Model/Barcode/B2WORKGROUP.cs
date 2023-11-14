using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Barcode
{
    public class B2WORKGROUP
    {
        [Key]
        public int id { get; set; }
        public string lines { get; set; }
        public string additionalCode { get; set; }
        public DateTime active_until { get; set; }
        public DateTime created_at { get; set; }
        public string wgShiftcode { get; set; }
        [Column(TypeName = "decimal(10, 5)")]
        public decimal? wgShiftHours { get; set; }
        [Column(TypeName = "decimal(10, 5)")]
        public decimal? wgShiftHeadcount { get; set; }
        [Column(TypeName = "decimal(10, 5)")]
        public decimal? wgShiftPlannedOutput { get; set; }
    }

    public class WorkgroupDetail
    {
        public int id { get; set; }
        public string line { get; set; }
        public string additionalCode { get; set; }
        public string ShiftCode { get; set; }
        public decimal? ShiftHours { get; set; }
        public decimal? ShiftHeadcount { get; set; }
        public decimal? ShiftPlannedOutput { get; set; }
        public string[] Operators { get; set; }
        public string[] MachinesAndTemplates { get; set; }
    }
}
