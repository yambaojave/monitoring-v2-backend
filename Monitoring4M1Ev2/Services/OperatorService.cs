using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class OperatorService : IOperatorService
    {
        private readonly ApplicationDbContext _db;

        public OperatorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public object GetOperator(string emplId)
        {
            object fullDetails = _db.OperatorDetails
                .Include(e => e.OperatorQualifications)
                    .ThenInclude(e => e.OperatorSafetyAnswers)
                .Include(e => e.OperatorQualifications)
                    .ThenInclude(e => e.OperatorEvaluations)
                .Include(e => e.OperatorQualifications)
                    .ThenInclude(e => e.InChargeDetails)
                .Select(od => new
                {
                    od.OperatorDetailId,
                    od.OperatorEmployeeId,
                    od.OperatorName,
                    od.DateAdded,
                    od.DateUpdate,
                    od.Active,
                    qualifications = od.OperatorQualifications.Select(oq => new
                    {
                        oq.QualificationId,
                        oq.Model,
                        oq.Process,
                        oq.Trainer,
                        oq.CreatedBy,
                        oq.OverallAssessment,
                        oq.ForReassessment,
                        oq.DateAdded,
                        CreatedByUser = $"{oq.InChargeDetails.LastName}, {oq.InChargeDetails.FirstName}",
                        operatorSafetyAnswers = (oq.OperatorSafetyAnswers != null) ? new
                        {
                            oq.OperatorSafetyAnswers.AnswerId,
                            oq.OperatorSafetyAnswers.Answer,
                            oq.OperatorSafetyAnswers.DateAdded
                        } : null,
                        operatorEvaluations = oq.OperatorEvaluations
                    })
                })

                .FirstOrDefault(e => e.OperatorEmployeeId == emplId);
                
            return fullDetails;
        }

        public object GetCurrentQualification(string empId)
        {
            OperatorDetail op = GetOperatorId(empId);
            OperatorQualification q = _db.OperatorQualifications
                .Include(e => e.InChargeDetails)
                .Include(e => e.OperatorEvaluations)
                .Include(e => e.OperatorSafetyAnswers)
                .FirstOrDefault(e => e.OperatorDetailId == op.OperatorDetailId && e.OverallAssessment == false && e.DateAdded.Year == DateTime.Now.Year);

            object[] qArray = new object[]
            {
                new
                {
                    q.QualificationId,
                    q.Model,
                    q.Process,
                    q.CreatedBy,
                    q.OverallAssessment,
                    q.DateAdded,
                    trainer = $"{q.InChargeDetails.LastName}, {q.InChargeDetails.FirstName}",
                    q.OperatorSafetyAnswers,
                    q.OperatorEvaluations
                }
            };

            object newQualificationFormat = new
            {
                op.OperatorDetailId,
                op.OperatorEmployeeId,
                op.OperatorName,
                op.DateAdded,
                op.DateUpdate,
                op.Active,
                qualifications = qArray
            };

            return newQualificationFormat;
        }

        public List<OperatorDetail> GetAllOperators()
        {
            return _db.OperatorDetails.ToList();
        }

        public OperatorDetail AddOperator(OperatorDetailDto dto)
        {
            var newOperator = new OperatorDetail
            {
                OperatorEmployeeId = dto.OperatorEmployeeId,
                OperatorName = dto.OperatorName,
            };

            _db.OperatorDetails.Add(newOperator);
            _db.SaveChanges();

            return newOperator;
        }

        public OperatorQualification AddOperatorQualification(OperatorQualificationDto dto)
        {
            var newQualification = new OperatorQualification
            {
                OperatorDetailId = dto.OperatorDetailId,
                Model = dto.Model,
                Process = dto.Process,
                Trainer = dto.Trainer,
                CreatedBy = dto.CreatedBy
            };

            _db.OperatorQualifications.Add(newQualification);
            _db.SaveChanges();

            return newQualification;
        }

        public void UpdateOperatorQualificationById(int id, OperatorQualificationDto dto)
        {
            var qualification = _db.OperatorQualifications.Find(id);

            qualification.Model = dto.Model;
            qualification.Process = dto.Process;
            qualification.CreatedBy = dto.CreatedBy;
            qualification.Trainer = dto.Trainer;

            _db.SaveChanges();
        }

        public OperatorSafetyAnswer AddOperatorSafetyAnswer(string answer, int qualificationId)
        {
            var newAnswer = new OperatorSafetyAnswer
            {
                Answer = answer,
                DateAdded = DateTime.Now,
                QualificationId = qualificationId
            };

            _db.OperatorSafetyAnswers.Add(newAnswer);
            _db.SaveChanges();

            return newAnswer;
        }

        public void UpdateOperatorSafetyAnswerById(string answer, int id)
        {
            var a = _db.OperatorSafetyAnswers.Find(id);

            a.Answer = answer;
            _db.SaveChanges();
            
        }

        public OperatorEvaluation AddEvaluation(EvaluationDto dto)
        {

            var newEvaluation = new OperatorEvaluation
            {
                CheckName = dto.CheckName,
                Description = dto.Description,
                Remarks = dto.Remarks,
                QualificationId = dto.QualificationId,
                DateAdded = DateTime.Now
            };

            _db.OperatorEvaluations.Add(newEvaluation);
            _db.SaveChanges();

            return newEvaluation;

        }

        public void UpdateEvaluation(EvaluationDto dto, int evaluationId)
        {
            var evaluation = _db.OperatorEvaluations.Find(evaluationId);

            evaluation.CheckName = dto.CheckName;
            evaluation.Description = dto.Description;
            evaluation.DateUpdated = DateTime.Now;

            _db.SaveChanges();
        }

        public void DeleteEvaluation(int evaluationId)
        {
            var entityToRemove = _db.OperatorEvaluations.Find(evaluationId);
            _db.OperatorEvaluations.Remove(entityToRemove);
            _db.SaveChanges();
        }

        public List<OperatorEvaluationPcs> GetOperatorQualificationPcsByEvalId (int evalId)
        {
            return _db.OperatorEvaluationPcs.Where(e => e.EvaluationId == evalId).ToList();
        }

        public OperatorEvaluationPcs AddPcsResult(OperatorEvaluationPcsDto dto)
        {
            var newPcsResult = new OperatorEvaluationPcs
            {
                PcsNo = dto.PcsNo,
                Result = dto.Result,
                DateAdded = DateTime.Now,
                EvaluationId = dto.EvaluationId
            };

            _db.OperatorEvaluationPcs.Add(newPcsResult);
            _db.SaveChanges();

            if(dto.Result == "Good")
            {
                var updateEval = _db.OperatorEvaluations.Find(dto.EvaluationId);
                var property = updateEval.GetType().GetProperty(dto.PcsNo);
                property.SetValue(updateEval, true);
                
                if(dto.PcsNo == "Pc30")
                {
                    updateEval.Remarks = "Good";
                }

                updateEval.DateUpdated = DateTime.Now;
                _db.SaveChanges();
            }
            


            return newPcsResult;
        }


        public bool EvaluateAssessment(int qualificationId)
        {
            /*
             *  TODO : Evaluating of Operator training performance 
             */
            var qualification = _db.OperatorQualifications.Include(e => e.OperatorEvaluations).FirstOrDefault(e => e.QualificationId == qualificationId);
            if(qualification.OperatorEvaluations.Count == 0)
            {
                return false;
            }


            //var evaluations = _db.OperatorEvaluations.Where(e => e.QualificationId == qualification.QualificationId).ToList();

            foreach (var eval in qualification.OperatorEvaluations)
            {
                if(eval.Remarks != "Good")
                {
                    return false;
                }
            }

            qualification.OverallAssessment = true;
            qualification.OverallAssessmentUpdate = DateTime.Now;
            _db.SaveChanges();
            return true;
        }

        /*
         *  CheckDataExists<T1, T2>(T1 data1, T2 data2)
         *  <T> data can be any value
         */

        public bool CheckDataExists<T>(T data, string table) where T : IConvertible
        {
            switch (table)
            {
                case "OPERATOR":
                    return _db.OperatorDetails.Any(e => e.OperatorEmployeeId == data.ToString());

                // In standby due to lot of situations can happen
                case "QUALIFICATION": 
                    return _db.OperatorQualifications.Any(e => e.QualificationId == Convert.ToInt32(data));
                case "EVALUATION":
                    return _db.OperatorEvaluations.Any(e => e.EvaluationId == Convert.ToInt32(data));
                case "ANSWER":
                    return _db.OperatorSafetyAnswers.Any(e => e.QualificationId == Convert.ToInt32(data));
            }
            return false;
        }

        public void OperatorUpdateTime(int id)
        {
            var dateToUpdate = _db.OperatorDetails.Find(id);
            dateToUpdate.DateUpdate = DateTime.Now;
            _db.SaveChanges();
        }

        private OperatorDetail GetOperatorId(string emplId)
        {
            return _db.OperatorDetails.Where(e => e.OperatorEmployeeId == emplId).FirstOrDefault();
        } 


    }
}
