using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
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
            return await _db.PlanHeaders.Include(e => e.PlanDetails).ToListAsync();
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
        }

        public async Task<PlanDetail> CreateDetailAsync(PlanDetailDto dto)
        {
            var newDetail = new PlanDetail
            {
                Operator = dto.Operator,
                Condition = dto.Condition,
                PlanHeaderId = dto.PlanHeaderId
            };

            _db.PlanDetails.Add(newDetail);
            await _db.SaveChangesAsync();

            return newDetail;
        }

        public async Task DeleteDetailASync(int id)
        {
            var detail = await _db.PlanDetails.FindAsync(id);
            _db.PlanDetails.Remove(detail);
        }
    }
}

