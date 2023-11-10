using Monitoring4M1Ev2.Model.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IOperatorService
    {
        void AddOperator(OperatorDetailDto dto);
        void AddOperatorQualification(OperatorQualificationDto dto);
    }
}
