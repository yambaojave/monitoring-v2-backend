using Monitoring4M1Ev2.Model.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Operator
{
    public class OperatorQualification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QualificationId { get; set; }
        public int OperatorDetailId { get; set; }
        public OperatorDetail OperatorDetail { get; set; }
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(50)]
        public string Process { get; set; }
        [MaxLength(50)]
        public string Trainer { get; set; }
        public bool OverallAssessment { get; set; } = false;
        public DateTime OverallAssessmentUpdate { get; set; }
        public int CreatedBy { get; set; } 
        [ForeignKey("CreatedBy")]
        public UserDetail InChargeDetails { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public OperatorSafetyAnswer OperatorSafetyAnswers { get; set; }
        public List<OperatorEvaluation> OperatorEvaluations { get; set; }
    }

    public class OperatorQualificationDto
    {
        public int OperatorDetailId { get; set; }
        public string Model { get; set; }
        public string Process { get; set; }
        public string Trainer { get; set; }
        public int CreatedBy { get; set; }
    }

}
