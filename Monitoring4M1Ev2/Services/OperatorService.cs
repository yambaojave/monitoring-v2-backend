using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Operator;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddOperator(OperatorDetailDto dto)
        {
            var newOperator = new OperatorDetail
            {
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
                InCharge = dto.InChange
            };

            _db.OperatorQualifications.Add(newQualification);
            _db.SaveChanges();
        }




    }
}

