using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Model
{
    public class Helpers
    {
        public static bool HasNullProperty(object obj)
        {
            if(obj == null)
            {
                return true;
            }

            foreach(var property in obj.GetType().GetProperties())
            {
                var value = property.GetValue(obj);
                if(value == null)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool shiftDateChecking(DateTime date, int shift)
        {
            int[] shiftDate = { 5, 6 };
            if (shiftDate.Contains(shift))
            {
                return true;
            }

            return false;
        }
    }
}
