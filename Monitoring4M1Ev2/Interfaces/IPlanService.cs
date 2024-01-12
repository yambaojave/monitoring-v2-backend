using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Model.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanHeader>> GetAllAsync();
        Task<PlanHeader> CreateHeaderAsync(PlanHeaderDto dto);
        Task DeleteHeaderAsync(int id);

        Task<PlanDetail> CreateDetailAsync(PlanDetailDto dto);
        Task DeleteDetailASync(int id);

    }
}
