using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Barcode
{
    public class B2WORKGROUPDETAIL
    {
        [Key]
        public int id { get; set; }
        public int workgroupId { get; set; }
        public string operatorCode { get; set; }
        public string machineCode { get; set; }
        public string operatorRole { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
