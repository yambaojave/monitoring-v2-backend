using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Machine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public int HeaderId { get; set; }
        public List<MachineSystemRemark> MachineSystemRemarks { get; set; }
    }
}
