using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialId { get; set; }
        [MaxLength(100)]
        public string Component { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        [MaxLength(10)]
        public string Type { get; set; }
        [MaxLength(5)]
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public int HeaderId { get; set; }
        public List<MaterialRemark> MaterialRemarks { get; set; }
        public List<MaterialSystemRemark> MaterialSystemRemarks { get; set; }

    }

    public class MaterialDto
    {
        public string Component { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HeaderId { get; set; }
    }
}
