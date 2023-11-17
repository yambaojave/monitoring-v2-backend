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
                        oq.OverallAssessment,
                        trainer = $"{oq.InChargeDetails.LastName}, {oq.InChargeDetails.FirstName}",
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
                InCharge = dto.InCharge
            };

            _db.OperatorQualifications.Add(newQualification);
            _db.SaveChanges();

            return newQualification;
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
            /*
             *  TODO : Evaluating of Operator training performance 
             */
            var qualification = _db.OperatorQualifications.Find(qualificationId);
            var evaluation = _db.OperatorEvaluations.Find(qualification.QualificationId);

            Type type = evaluation.GetType();

            PropertyInfo[] boolProperties = type.GetProperties()
                .Where(p => p.PropertyType == typeof(bool?))
                .ToArray();
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




    }
}
