using Monitoring4M1Ev2.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetJsphEmployees();
        List<Employee> GetContractorEmployees();
        Employee GetDetails(string emplId);
        bool IsValidEmployeeFormat(string input);
    }
}
