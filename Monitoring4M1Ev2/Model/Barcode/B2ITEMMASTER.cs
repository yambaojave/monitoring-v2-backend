using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Barcode
{
    public class B2ITEMMASTER
    {
        [Key]
        public int id { get; set; } 
        public string ITEMNO { get; set; }
        public string DESCRIPTION1 { get; set; }
        public string DESCRIPTION2 { get; set; }

        public string FullDescription
        {
            get
            {
                return $"{DESCRIPTION1} {DESCRIPTION2}";
            }
        }
    }
}
