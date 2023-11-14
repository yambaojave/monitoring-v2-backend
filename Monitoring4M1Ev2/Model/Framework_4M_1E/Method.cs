using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Method
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MethodId { get; set; }
        [MaxLength(50)]
        public string ControlNumber { get; set; }
        [MaxLength(5)]
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public int HeaderId { get; set; }
        public List<MethodRemark> MethodRemarks { get; set; }
        public List<MethodSystemRemark> MethodSystemRemarks { get; set; }
    }
}
