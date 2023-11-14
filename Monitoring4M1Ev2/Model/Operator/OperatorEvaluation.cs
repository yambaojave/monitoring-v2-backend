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
        public string CheckName { get; set; }
        public string Description { get; set; }
        public bool? Pc1 { get; set; }
        public bool? Pc2 { get; set; }
        public bool? Pc3 { get; set; }
        public bool? Pc4 { get; set; }
        public bool? Pc5 { get; set; }
        public bool? Pc6 { get; set; }
        public bool? Pc7 { get; set; }
        public bool? Pc8 { get; set; }
        public bool? Pc9 { get; set; }
        public bool? Pc10 { get; set; }
        public bool? Pc11 { get; set; }
        public bool? Pc12 { get; set; }
        public bool? Pc13 { get; set; }
        public bool? Pc14 { get; set; }
        public bool? Pc15 { get; set; }
        public bool? Pc16 { get; set; }
        public bool? Pc17 { get; set; }
        public bool? Pc18 { get; set; }
        public bool? Pc19 { get; set; }
        public bool? Pc20 { get; set; }
        public bool? Pc21 { get; set; }
        public bool? Pc22 { get; set; }
        public bool? Pc23 { get; set; }
        public bool? Pc24 { get; set; }
        public bool? Pc25 { get; set; }
        public bool? Pc26 { get; set; }
        public bool? Pc27 { get; set; }
        public bool? Pc28 { get; set; }
        public bool? Pc29 { get; set; }
        public bool? Pc30 { get; set; }
        public string Remarks { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        public int QualificationId { get; set; }
    }

    public class EvaluationDto
    {
        public string CheckName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public int QualificationId { get; set; }
    }

    public class ItemEvaluationDto
    {
        public bool? Pc1 { get; set; }
        public bool? Pc2 { get; set; }
        public bool? Pc3 { get; set; }
        public bool? Pc4 { get; set; }
        public bool? Pc5 { get; set; }
        public bool? Pc6 { get; set; }
        public bool? Pc7 { get; set; }
        public bool? Pc8 { get; set; }
        public bool? Pc9 { get; set; }
        public bool? Pc10 { get; set; }
        public bool? Pc11 { get; set; }
        public bool? Pc12 { get; set; }
        public bool? Pc13 { get; set; }
        public bool? Pc14 { get; set; }
        public bool? Pc15 { get; set; }
        public bool? Pc16 { get; set; }
        public bool? Pc17 { get; set; }
        public bool? Pc18 { get; set; }
        public bool? Pc19 { get; set; }
        public bool? Pc20 { get; set; }
        public bool? Pc21 { get; set; }
        public bool? Pc22 { get; set; }
        public bool? Pc23 { get; set; }
        public bool? Pc24 { get; set; }
        public bool? Pc25 { get; set; }
        public bool? Pc26 { get; set; }
        public bool? Pc27 { get; set; }
        public bool? Pc28 { get; set; }
        public bool? Pc29 { get; set; }
        public bool? Pc30 { get; set; }
    }

    public class CombinedEvaluation
    {
        public EvaluationDto EvaluationDto { get; set; }
        public ItemEvaluationDto ItemEvaluationDto { get; set; }
        public string process { get; set; }
        public int evalId { get; set; }
        public int qualifyId { get; set; }
    }
}


