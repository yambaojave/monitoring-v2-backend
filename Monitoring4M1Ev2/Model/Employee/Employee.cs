using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model.Employee
{
    public class Employee
    {
        [Key]
        public string empd_ID { get; set; }
        public string emp_Card { get; set; }
        public string lname { get; set; }
        public string mname { get; set; }
        public string fname { get; set; }
        public bool active { get; set; }

        public string clean_emp
        {
            get
            {
                //return Regex.Replace(empd_ID, @"\s+", " ");
                return empd_ID.Replace(" ", "");
            }
        }

        public string createUsername
        {
            get
            {
                return $"{lname.ToLower()}{fname.Substring(0,1).ToLower()}";
            }
        }
    }
}
