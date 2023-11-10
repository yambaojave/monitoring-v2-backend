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
        public string OperatorName { get; set; }
        public string Model { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime Update { get; set; }
        public bool Active { get; set; } = true;
    }

    public class OperatorDetailDto
    {
        public string OperatorName { get; set; }
        public string Model { get; set; }
    }
}
