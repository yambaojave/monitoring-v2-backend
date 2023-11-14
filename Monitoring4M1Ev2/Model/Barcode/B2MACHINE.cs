using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Barcode
{
    public class B2MACHINE
    {
        [Key]
        public int id { get; set; }
        public string machinename { get; set; }
        public int locationid { get; set; }
        public string equipmentcode { get; set; }
        public bool isActive { get; set; }
    }
}
