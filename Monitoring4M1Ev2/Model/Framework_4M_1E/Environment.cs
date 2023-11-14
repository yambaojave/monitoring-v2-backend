using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Environment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnvironmentId { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        public decimal Temperature { get; set; }
        [MaxLength(5)]
        public string Lighting { get; set; }
        [MaxLength(255)]
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public int HeaderId { get; set; }
    }
}
