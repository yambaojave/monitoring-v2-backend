using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class M4EHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeaderId { get; set; }
        public int WorkGroupId { get; set; }
        public int CreatedBy { get; set; }
        public string Line{ get; set; }
        public string Model { get; set; }
        public int OperatorCount { get; set; }
        public int OperationCount { get; set; }
        public int ShiftCode { get; set; }
        public DateTime DateAdded { get; set; }
        public int PlanId { get; set; } // to be added
        public string Type { get; set; }
        public bool Finalized { get; set; }
        public DateTime FinalizedDate { get; set; }
        public M4EHeaderRemark M4EHeaderRemarks { get; set; } // for testing getting a one to one result
        public List<Man> Mans { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Method> Methods { get; set; }
        public List<Material> Materials { get; set; }
        public List<Environment> Environments { get; set; }
        public List<Output> Outputs { get; set; }
        public IEnumerable<MonitoringResult> MonitoringResults { get; set; }
    }

    public class M4EHeaderDto
    {
        public int WorkGroupId { get; set; }
        public int CreatedBy { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
        public int OperatorCount { get; set; }
        public int OperationCount { get; set; }
        public int ShiftCode { get; set; }
    }

    public class LineRequest
    {
        public string[] Lines { get; set; }
    }


    public class GroupM4EData
    {
        public string Operator { get; set; }
        public string Process { get; set; }
        public string ControlNumber { get; set; }
        public string Machine { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        
    }
}
