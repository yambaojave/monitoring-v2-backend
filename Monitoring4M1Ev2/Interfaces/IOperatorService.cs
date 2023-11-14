using Monitoring4M1Ev2.Model.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IOperatorService
    {
        // CREATION LIST OF DATA
        void AddOperator(OperatorDetailDto dto);
        void AddOperatorQualification(OperatorQualificationDto dto);
        void AddOperatorSafetyAnswer(string answer, int qualificationId);
        void AddUpdateEvaluation(EvaluationDto dto, ItemEvaluationDto itemDto, string process, int evalId, int qualifyId);

        // GETTING LIST OF DATA
        object GetOperator(int id);
        
    }
}
