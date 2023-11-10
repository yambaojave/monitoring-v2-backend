﻿using Monitoring4M1Ev2.Model.User;
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
        [JsonIgnore]
        public OperatorDetail OperatorDetail { get; set; }
        public string Process { get; set; }
        public bool OverallAssessment { get; set; } = false;
        public int InCharge { get; set; } // User with Trainer role
        [JsonIgnore]
        public UserDetail UserDetail { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public List<OperatorSafetyAnswer> OperatorSafetyAnswers { get; set; }
        public List<OperatorEvaluation> OperatorEvaluations { get; set; }
    }

    public class OperatorQualificationDto
    {
        public int OperatorDetailId { get; set; }
        public string Process { get; set; }
        public int InChange { get; set; }
    }
}