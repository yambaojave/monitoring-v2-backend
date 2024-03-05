using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Operator
{
    public class OperatorDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorDetailId { get; set; }
        [MaxLength(50)]
        public string OperatorEmployeeId { get; set; }
        [MaxLength(100)]
        public string OperatorName { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime DateUpdate { get; set; }
        public bool Active { get; set; } = true;
        public List<OperatorQualification> OperatorQualifications { get; set; }
    }

    public class OperatorDetailDto
    {
        public string OperatorEmployeeId { get; set; }
        public string OperatorName { get; set; }
    }

    public class OperatorCheckDto
    {
        public int HeaderId { get; set; }
        public string OperatorEmployeeId { get; set; }
    }
    
}
