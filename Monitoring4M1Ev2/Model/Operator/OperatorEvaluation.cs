using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Operator
{
    public class OperatorEvaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EvaluationId { get; set; }
        [MaxLength(100)]
        public string CheckName { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool Pc1 { get; set; } = false;
        public bool Pc2 { get; set; } = false;
        public bool Pc3 { get; set; } = false;
        public bool Pc4 { get; set; } = false;
        public bool Pc5 { get; set; } = false;
        public bool Pc6 { get; set; } = false;
        public bool Pc7 { get; set; } = false;
        public bool Pc8 { get; set; } = false;
        public bool Pc9 { get; set; } = false;
        public bool Pc10 { get; set; } = false;
        public bool Pc11 { get; set; } = false;
        public bool Pc12 { get; set; } = false;
        public bool Pc13 { get; set; } = false;
        public bool Pc14 { get; set; } = false;
        public bool Pc15 { get; set; } = false;
        public bool Pc16 { get; set; } = false;
        public bool Pc17 { get; set; } = false;
        public bool Pc18 { get; set; } = false;
        public bool Pc19 { get; set; } = false;
        public bool Pc20 { get; set; } = false;
        public bool Pc21 { get; set; } = false;
        public bool Pc22 { get; set; } = false;
        public bool Pc23 { get; set; } = false;
        public bool Pc24 { get; set; } = false;
        public bool Pc25 { get; set; } = false;
        public bool Pc26 { get; set; } = false;
        public bool Pc27 { get; set; } = false;
        public bool Pc28 { get; set; } = false;
        public bool Pc29 { get; set; } = false;
        public bool Pc30 { get; set; } = false;
        public string Remarks { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int QualificationId { get; set; }
        public List<OperatorEvaluationPcs> OperatorQualificationPcs { get; set; }
    }

    public class EvaluationDto
    {
        public string CheckName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; } = "";
        public int QualificationId { get; set; }
    }

    public class UpdateEvaluationDto
    {
        public EvaluationDto ItemEvaluationDto { get; set; }
        public int EvaluationId { get; set; }
    }
}


