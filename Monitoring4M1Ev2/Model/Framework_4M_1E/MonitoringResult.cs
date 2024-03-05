using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class MonitoringResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Man { get; set; }
        public string Machine { get; set; }
        public string Method { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime DateAdded { get; set; }
        public int HeaderId { get; set; }
    }
}
