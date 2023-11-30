using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Operator
{
    public class OperatorEvaluationPcs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PcsId { get; set; }
        public string PcsNo { get; set; }
        public string Result { get; set; }
        public DateTime DateAdded { get; set; }
        public int EvaluationId { get; set; }
    }

    public class OperatorEvaluationPcsDto
    {
        public string PcsNo { get; set; }
        public string Result { get; set; }
        public int EvaluationId { get; set; }
    }
}
