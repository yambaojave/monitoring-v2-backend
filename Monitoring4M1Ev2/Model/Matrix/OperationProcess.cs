using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Matrix
{
    public class OperationProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MachineId { get; set; }
        public string OperationName { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public DateTime DateUpdated { get; set; }
        public int WIId { get; set; }
        public WIMatrix WIMatrix { get; set; }
    }

    public class OperationProcessDto
    {
        public string OperationName { get; set; }
        public int WIId { get; set; }
    }
}
