using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class M4EHeaderRemark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeaderRemarkId { get; set; }
        // Overall Remarks that can be manually inputted by end-user for showing solution how to solve an issue
        [MaxLength(255)]
        public string ManRemark { get; set; }
        public TimeSpan ManRemarkTimeUpdate { get; set; }
        [MaxLength(255)]
        public string MachineRemark { get; set; }
        public TimeSpan MachineRemarkUpdate { get; set; }
        [MaxLength(255)]
        public string MethodRemark { get; set; }
        public TimeSpan MethodRemarkUpdate { get; set; }
        [MaxLength(255)]
        public string MaterialRemark { get; set; }
        public TimeSpan MaterialRemarkUpdate { get; set; }
        [MaxLength(255)]
        public string EnvironmentRemark { get; set; }
        public TimeSpan EnvironmentRemarkUpdate { get; set; }
        public int HeaderId { get; set; }
    }
}
