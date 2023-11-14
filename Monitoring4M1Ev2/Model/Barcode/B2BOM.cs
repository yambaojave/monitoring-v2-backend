using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Barcode
{
    public class B2BOM
    {
        [Key]
        public string BOMCode { get; set; }
        public string ParentDesc { get; set; }
        public string ParentProdLine { get; set; }
        public string ParentItemType { get; set; }
        public string ParentStatus { get; set; }
        public string ComponentItem { get; set; }
        public string Description { get; set; }
        public DateTime? EndEffective { get; set; }
    }
}
