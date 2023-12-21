using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Matrix
{
    public class WIMatrix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WIId { get; set; }
        public string ProcessNumber { get; set; }
        public string ControlNumber { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public DateTime DateUpdated { get; set; }

        public int PModelId { get; set; }
        public ProductionModel ProductionModel { get; set; }

        public List<OperationProcess> OperationProcesses { get; set; }
    }


    public class WIMatrixDto
    {
        public string ProcessNumber { get; set; }
        public string ControlNumber { get; set; }
        public int PModelId { get; set; }
    }
}
