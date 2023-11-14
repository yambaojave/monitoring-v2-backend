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

        public object GetOperator(int id)
        {
            object fullDetails = _db.OperatorDetails
                .Include(e => e.OperatorQualification)
                    .ThenInclude(e => e.OperatorSafetyAnswers)
                .Include(e => e.OperatorQualification)
                    .ThenInclude(e => e.OperatorEvaluations)
                .Include(e => e.OperatorQualification)
                    .ThenInclude(e => e.InChargeDetails)
                .Select(od => new
                {
                    od.OperatorDetailId,
                    od.OperatorEmployeeId,
                    od.OperatorName,
                    od.Model,
                    od.DateAdded,
                    od.DateUpdate,
                    od.Active,
                    qualifications = new
                    {
                        od.OperatorQualification.QualificationId,
                        od.OperatorQualification.Process,
                        od.OperatorQualification.OverallAssessment,
                        trainer = $"{od.OperatorQualification.InChargeDetails.LastName}, {od.OperatorQualification.InChargeDetails.FirstName}",
                        od.OperatorQualification.DateAdded,
                        operatorSafetyAnswers = new
                        {
                            od.OperatorQualification.OperatorSafetyAnswers.AnswerId,
                            od.OperatorQualification.OperatorSafetyAnswers.Answer,
                            od.OperatorQualification.OperatorSafetyAnswers.DateAdded,
                        },
                        operatorEvaluations = od.OperatorQualification.OperatorEvaluations
                    }
                })

                .FirstOrDefault(e => e.OperatorDetailId == id);
                



            return fullDetails;
        }

        public void AddOperator(OperatorDetailDto dto)
        {
            var newOperator = new OperatorDetail
            {
                OperatorEmployeeId = dto.OperatorEmployeeId,
                OperatorName = dto.OperatorName,
                Model = dto.Model,
            };

            _db.OperatorDetails.Add(newOperator);
            _db.SaveChanges();
        }

        public void AddOperatorQualification(OperatorQualificationDto dto)
        {
            var newQualification = new OperatorQualification
            {
                OperatorDetailId = dto.OperatorDetailId,
                Process = dto.Process,
                InCharge = dto.InCharge
            };

            _db.OperatorQualifications.Add(newQualification);
            _db.SaveChanges();
        }

        public void AddOperatorSafetyAnswer(string answer, int qualificationId)
        {
            var newAnswer = new OperatorSafetyAnswer
            {
                Answer = answer,
                DateAdded = DateTime.Now,
                QualificationId = qualificationId
            };

            _db.OperatorSafetyAnswers.Add(newAnswer);
            _db.SaveChanges();
        }

        public void AddUpdateEvaluation(EvaluationDto dto, ItemEvaluationDto itemDto, string process, int evalId, int qualifyId)
        {
            if(process == "ADD")
            {
                var newEvaluation = new OperatorEvaluation
                {
                    CheckName = dto.CheckName,
                    Description = dto.Description,
                    Remarks = dto.Remarks,
                    QualificationId = qualifyId,
                    DateAdded = DateTime.Now
                };

                _db.OperatorEvaluations.Add(newEvaluation);
                _db.SaveChanges();

                if(itemDto != null)
                {
                    UpdateEvaluation(newEvaluation.EvaluationId, itemDto);
                }
            }
            else
            {
                UpdateEvaluation(evalId, itemDto);
            }
        }

        public void UpdateEvaluation(int evaluationId, ItemEvaluationDto dto)
        {
            var evaluation = _db.OperatorEvaluations.Find(evaluationId);

            evaluation.Pc1 = dto.Pc1;
            evaluation.Pc2 = dto.Pc2;
            evaluation.Pc3 = dto.Pc3;
            evaluation.Pc4 = dto.Pc4;
            evaluation.Pc5 = dto.Pc5;
            evaluation.Pc6 = dto.Pc6;
            evaluation.Pc7 = dto.Pc7;
            evaluation.Pc8 = dto.Pc8;
            evaluation.Pc9 = dto.Pc9;
            evaluation.Pc10 = dto.Pc10;
            evaluation.Pc11 = dto.Pc11;
            evaluation.Pc12 = dto.Pc12;
            evaluation.Pc13 = dto.Pc13;
            evaluation.Pc14 = dto.Pc14;
            evaluation.Pc15 = dto.Pc15;
            evaluation.Pc16 = dto.Pc16;
            evaluation.Pc17 = dto.Pc17;
            evaluation.Pc18 = dto.Pc18;
            evaluation.Pc19 = dto.Pc19;
            evaluation.Pc20 = dto.Pc20;
            evaluation.Pc21 = dto.Pc21;
            evaluation.Pc22 = dto.Pc22;
            evaluation.Pc23 = dto.Pc23;
            evaluation.Pc24 = dto.Pc24;
            evaluation.Pc25 = dto.Pc25;
            evaluation.Pc26 = dto.Pc26;
            evaluation.Pc27 = dto.Pc27;
            evaluation.Pc28 = dto.Pc28;
            evaluation.Pc29 = dto.Pc29;
            evaluation.Pc30 = dto.Pc30;
            evaluation.DateUpdated = DateTime.Now;

            _db.SaveChanges();
        }


        public void EvaluateAssessment(int qualificationId)
        {
            var qualification = _db.OperatorQualifications.Find(qualificationId);
            var evaluation = _db.OperatorEvaluations.Find(qualification.QualificationId);

            Type type = evaluation.GetType();

            PropertyInfo[] boolProperties = type.GetProperties()
                .Where(p => p.PropertyType == typeof(bool?))
                .ToArray();


        }




    }
}
