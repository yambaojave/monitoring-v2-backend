using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Framework_4M_1E
{
    public class Trainee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TraineeId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public int ManId { get; set; }
    }
}
