using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Matrix;
using Monitoring4M1Ev2.Model.Operator;
using Monitoring4M1Ev2.Model.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class PlanService : IPlanService
    {
        private readonly ApplicationDbContext _db;
        

        public PlanService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PlanHeader>> GetAllAsync()
        {
            return await _db.PlanHeaders.ToListAsync();
        }

        public async Task<IEnumerable<PlanDetail>> GetAllDetailByIdAsync(int HeaderId)
        {
            return await _db.PlanDetails.Where(e => e.PlanHeaderId == HeaderId).ToListAsync();
        }

        public async Task<PlanHeader> CreateHeaderAsync(PlanHeaderDto dto)
        {
            var newPlan = new PlanHeader
            {
                Model = dto.Model,
                Shift = dto.Shift,
                Line = dto.Line,
                IsUsed = false,
                PlanDate = dto.PlanDate,
                CreatedBy = dto.CreatedBy,
                CreatedDate = DateTime.Now
            };

            _db.PlanHeaders.Add(newPlan);
            await _db.SaveChangesAsync();

            return newPlan;
        }

        public async Task DeleteHeaderAsync(int id)
        {
            var header = await _db.PlanHeaders.FindAsync(id);
            _db.PlanHeaders.Remove(header);

            await _db.SaveChangesAsync();
        }

        public async Task<PlanDetail> CreateDetailAsync(PlanDetailDto dto)
        {
            var newDetail = new PlanDetail
            {
                Operator = dto.Operator,
                Condition = dto.Condition,
                Process = dto.Process,
                ControlNumber = dto.ControlNumber,
                Machines = dto.Machines,
                PlanHeaderId = dto.PlanHeaderId,
                CreatedDate = DateTime.Now
            };

            _db.PlanDetails.Add(newDetail);
            await _db.SaveChangesAsync();

            return newDetail;
        }

        public async Task DeleteDetailASync(int id)
        {
            var detail = await _db.PlanDetails.FindAsync(id);
            _db.PlanDetails.Remove(detail);

            await _db.SaveChangesAsync();
        }

        public async Task<PlanHeader> GetHeaderByIdAsync(int HeaderId)
        {
            return await _db.PlanHeaders.FirstOrDefaultAsync(e => e.PlanHeaderId == HeaderId);
        }

        public async Task UpdateHeaderById(PlanHeader planHeader)
        {
            var header = await _db.PlanHeaders.FindAsync(planHeader.PlanHeaderId);
            // Add updated Date

            header.Model = planHeader.Model;
            header.Shift = planHeader.Shift;
            header.Line = planHeader.Line;
            header.PlanDate = planHeader.PlanDate;

            await _db.SaveChangesAsync();
        }

        public async Task<List<PlanDetail>> GetCloneNewDetails(IEnumerable<PlanDetail> details, string model)
        {
            List<PlanDetail> newCloneList = new List<PlanDetail>();
            IEnumerable<OperatorDetail> opDetails = await _db.OperatorDetails.Include(e => e.OperatorQualifications).Where(e => e.Active == true).ToListAsync();
            ProductionModel matrix = await _db.ProductionModels.Include(e => e.WIMatrices).ThenInclude(e => e.OperationProcesses).Where(e => e.ModelName == model).FirstOrDefaultAsync();


            foreach(var detail in details)
            {
                bool condition = opDetails
                    .Where(e => e.OperatorEmployeeId == detail.Operator)
                    .SelectMany(od => od.OperatorQualifications
                        .Where(x => x.Model == model && x.Process
                            .Contains(detail.Process)).OrderByDescending(i => i.OverallAssessmentUpdate)
                                .Select(q => q.ForReassessment)).FirstOrDefault();

                var selectedMatrix = matrix.WIMatrices.Where(e => e.ProcessNumber == detail.Process).ToList();

                string controlNumber = selectedMatrix.Select(e => e.ControlNumber).FirstOrDefault().ToString();
                string[] machineArray = selectedMatrix.SelectMany(od => od.OperationProcesses).Where(e => e.IsActive == true).Select(e => e.OperationName).ToArray();
                string machines = String.Join(", ", machineArray);

                newCloneList.Add(new PlanDetail
                {
                    Operator = detail.Operator,
                    Condition = condition ? "BAD" : "GOOD",
                    Process = detail.Process,
                    ControlNumber = controlNumber,
                    Machines = machines,
                });

            }

            return newCloneList;
        }
    }
}
