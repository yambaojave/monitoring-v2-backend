using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class MethodRemark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MethodRemarkId { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public TimeSpan TimeAdded { get; set; }
        public int MethodId { get; set; }
    }
}
