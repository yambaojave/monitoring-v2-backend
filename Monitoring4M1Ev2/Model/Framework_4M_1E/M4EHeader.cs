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
        public M4EHeaderRemark M4EHeaderRemarks { get; set; } // for testing getting a one to one result
        public List<Man> Mans { get; set; }
        public List<Machine> Machines { get; set; }
        public List<Method> Methods { get; set; }
        public List<Material> Materials { get; set; }
        public List<Environment> Environments { get; set; }
    }
}
