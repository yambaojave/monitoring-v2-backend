﻿using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JsphDbContext _jsph;
        private readonly ContractorDbContext _contractor;

        public EmployeeService(JsphDbContext jsph, ContractorDbContext contractor)
        {
            _jsph = jsph;
            _contractor = contractor;
        }

        string jsphEmployeeChecking = "O-000";
        string contractEmployeeChecking = "O-";

        /*
         *  Getting of all active employees either from JSPH or Contractor 
         */
        public List<Employee> GetJsphEmployees()
        {
            return _jsph.employee.Where(e => e.active == true).ToList();
        }

        public List<Employee> GetContractorEmployees()
        {
            return _contractor.employee.Where(e => e.active == true).ToList();
        }

        public Employee GetDetails(string emplId)
        {
            var operatorDetails = emplId.Contains(jsphEmployeeChecking)
                ? GetJsphEmployees().FirstOrDefault(e => e.clean_emp == emplId.Replace(jsphEmployeeChecking, string.Empty))
                : GetContractorEmployees().FirstOrDefault(e => e.emp_Card == String.Concat("00", emplId.Replace(contractEmployeeChecking, string.Empty)));

            return operatorDetails;
        }

        public bool IsValidEmployeeFormat(string input)
        {
            bool containsJsphFormat = input.Contains(jsphEmployeeChecking);
            bool containsContractFormat = input.Contains(contractEmployeeChecking);

            return containsJsphFormat || containsContractFormat;
        }

    }
}
