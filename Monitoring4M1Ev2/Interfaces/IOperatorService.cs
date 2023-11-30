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
        OperatorDetail AddOperator(OperatorDetailDto dto);
        List<OperatorDetail> GetAllOperators();
        OperatorQualification AddOperatorQualification(OperatorQualificationDto dto);
        OperatorSafetyAnswer AddOperatorSafetyAnswer(string answer, int qualificationId);
        OperatorEvaluation AddEvaluation(EvaluationDto dto);
        object GetCurrentQualification(string empId);
        OperatorEvaluationPcs AddPcsResult(OperatorEvaluationPcsDto dto);

        // GETTING LIST OF DATA
        object GetOperator(string emplId);
        List<OperatorEvaluationPcs> GetOperatorQualificationPcsByEvalId(int evalId);

        // DATA CHECKING
        bool CheckDataExists<T>(T data, string table) where T : IConvertible;

        // Update
        void OperatorUpdateTime(int id);
        void UpdateEvaluation(EvaluationDto dto, int evaluationId);
        void UpdateOperatorQualificationById(int id, OperatorQualificationDto dto);
        void UpdateOperatorSafetyAnswerById(string answer, int id);

        // DELETE
        void DeleteEvaluation(int evaluationId);

    }
}
