using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Matrix
{
    public class ProductionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PModelId { get; set; }
        [MaxLength(50)]
        [Required]
        public string ModelName { get; set; }
        [MaxLength(50)]
        [Required]
        public string ModelDescription { get; set; }
        public int? ModelHeadCount { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public DateTime DateUpdated { get; set; }
        public List<WIMatrix> WIMatrices { get; set; }
    }

    public class ProductionModelDto
    {
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }
        public int ModelHeadCount { get; set; }
    }
}
