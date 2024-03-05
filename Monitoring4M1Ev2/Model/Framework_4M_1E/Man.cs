using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Man
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManId { get; set; }
        public string EmployeeId { get; set; }
   
        public string Status { get; set; }
        public string OperatorReplacementId { get; set; }
        public TimeSpan ReplacementTimeChange { get; set; }
        public string ChangeRemark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int HeaderId { get; set; }
        
        public List<Trainee> Trainees { get; set; }
        public List<ManRemark> ManRemarks { get; set; }
        public List<ManSystemRemark> ManSystemRemarks { get; set; }
    }

    public class ManDto
    {
        public string EmployeeId { get; set; }

        public string Status { get; set; }
        public int HeaderId { get; set; }
    }

    public class ReplacementDto
    {
        public int ManId { get; set; }
        public string EmployeeId { get; set; }
        public string ChangeRemark { get; set; }
    }
}
