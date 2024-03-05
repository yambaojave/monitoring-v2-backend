using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Matrix
{
    public class Template
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public DateTime DateUpdated { get; set; }
        public int MachineId { get; set; }
        public OperationProcess OperationProcess { get; set; }
    }

    public class TemplateDto
    {
        public string TemplateName { get; set; }
        public int MachineId { get; set; }
        public int PModelId { get; set; }
    }

}
