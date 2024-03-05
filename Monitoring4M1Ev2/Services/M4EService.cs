using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Framework_4M_1E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class M4EService : IM4EService
    {
        private readonly ApplicationDbContext _db;

        public M4EService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<M4EHeader> GetLatestWorkingHeaderByLine(string line)
        {
            return await _db.M4EHeaders
                .Include(e => e.Mans)
                .Include(e => e.Machines)
                .Include(e => e.Materials)
                .Include(e => e.Methods)
                .Where(e => e.Line == line).OrderByDescending(e => e.HeaderId).FirstOrDefaultAsync();
        }



        public async Task<M4EHeader> CreateHeader(M4EHeaderDto dto, int planId, string type)
        {
            var newHeader = new M4EHeader
            {
                WorkGroupId = dto.WorkGroupId,
                CreatedBy = dto.CreatedBy,
                Line = dto.Line,
                Model = dto.Model,
                OperatorCount = dto.OperatorCount,
                OperationCount = dto.OperationCount,
                ShiftCode = dto.ShiftCode,
                DateAdded = DateTime.Now,
                PlanId = planId,
                Type = type
            };

            _db.M4EHeaders.Add(newHeader);
            await _db.SaveChangesAsync();

            return newHeader;
        }

        public async Task<IEnumerable<M4EHeader>> GetAllHeaderByUserLinesAsync(string[] lines)
        {
            return await _db.M4EHeaders.Where(e => lines.Contains(e.Line)).ToListAsync();
        }

        public async Task<bool> WorkGroupExist(int workgroupId)
        {
            return await _db.M4EHeaders.AnyAsync(e => e.WorkGroupId == workgroupId);
        }

        public async Task AddManDetails(ManDto dto)
        {
            var newMan = new Man
            {
                EmployeeId = dto.EmployeeId,
                Status = dto.Status,
                HeaderId = dto.HeaderId,
                DateAdded = DateTime.Now
            };

            await _db.Mans.AddAsync(newMan);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ManExist(string OperatorId, int newHeaderId)
        {
            return await _db.Mans.AnyAsync(e => e.EmployeeId == OperatorId && e.HeaderId == newHeaderId);
        }

        public async Task AddMachineDetails(MachineDto dto)
        {
            var newMachine = new Machine
            {
                MachineName = dto.MachineName,
                Status = dto.Status,
                HeaderId = dto.HeaderId,
                DateAdded = DateTime.Now
            };

            await _db.Machines.AddAsync(newMachine);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> MachineExist(string machine, int newHeaderId)
        {
            return await _db.Machines.AnyAsync(e => e.MachineName == machine && e.HeaderId == newHeaderId);
        }

        public async Task<IEnumerable<Man>> GetManByHeaderIdAsync(int id)
        {
            return await _db.Mans.Where(e => e.HeaderId == id).ToListAsync();
        }

        public async Task<IEnumerable<Machine>> GetMachineByHeaderIdAsync(int id)
        {
            return await _db.Machines.Where(e => e.HeaderId == id).ToListAsync();
        }

        public async Task AddMaterial(MaterialDto dto)
        {
            var newMaterial = new Material
            {
                Component = dto.Component,
                Description = dto.Description,
                Type = dto.Type,
                Status = dto.Status,
                HeaderId = dto.HeaderId,
                DateAdded = DateTime.Now
            };

            await _db.Materials.AddAsync(newMaterial);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Material>> GetMaterialByHeaderIdAsync(int id)
        {
            return await _db.Materials.Where(e => e.HeaderId == id).ToListAsync();
        }

        public async Task AddOutput(OutputDto dto)
        {
            var newOutput = new Output
            {
                TimeRange = dto.TimeRange,
                Plan = dto.Plan,
                Actual = dto.Actual,
                Difference = dto.Difference,
                HeaderId = dto.HeaderId,
                Updated = dto.Updated
            };

            await _db.Outputs.AddAsync(newOutput);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Output>> GetOutputByHeaderIdAsync(int id)
        {
            return await _db.Outputs.Where(e => e.HeaderId == id).ToListAsync();
        }

        public async Task UpdateOutputById(OutputCompute compute)
        {
            var outputs = await _db.Outputs.Where(e => e.HeaderId == compute.HeaderId).OrderByDescending(e => e.OutputId).ToListAsync();
            int maxActualSum = outputs.Sum(e => e.UserInput); // Sum of all outputs
            int timePlanOutput = outputs.Where(e => e.OutputId == compute.OutputId).Select(e => e.Plan).FirstOrDefault(); // Get the Expected output
            int currentDifference = maxActualSum - timePlanOutput; // Getting the difference
            

            var sO = await _db.Outputs.FindAsync(compute.OutputId);

            sO.Actual = maxActualSum + compute.Actual;
            sO.Difference = compute.Actual + currentDifference;
            sO.UserInput = compute.Actual;
            sO.Updated = true;
            sO.UpdateDate = DateTime.Now;
            sO.Remarks = compute.Remarks;


            // Update next output to show input button
            int highestId = outputs.Select(e => e.OutputId).FirstOrDefault();

            if(compute.OutputId != highestId)
            {
                var sO1 = await _db.Outputs.FindAsync(compute.OutputId + 1);
                sO1.Updated = false;
            }
            
            await _db.SaveChangesAsync();


        }

        public async Task<M4EHeader> GetHeaderById(int headerId)
        {
            return await _db.M4EHeaders.FirstOrDefaultAsync(e => e.HeaderId == headerId);
        }

        public async Task UpdateReplacement(ReplacementDto dto)
        {
            var man = await _db.Mans.FindAsync(dto.ManId);

            man.OperatorReplacementId = dto.EmployeeId;
            man.ChangeRemark = dto.ChangeRemark;
            man.DateUpdated = DateTime.Now;
            man.ReplacementTimeChange = DateTime.Now.TimeOfDay;

            await _db.SaveChangesAsync();
        }

        public async Task<Man> GetManDetailById(int manId)
        {
            return await _db.Mans.FirstOrDefaultAsync(e => e.ManId == manId);
        }

        public async Task AddEnvironment(EnvironmentDto dto)
        {
            var newEnvi = new Model.Framework_4M_1E.Environment
            {
                Temperature = dto.Temperature,
                Lighting = dto.Lighting,
                Remark = dto.Remark,
                DateAdded = DateTime.Now,
                HeaderId = dto.HeaderId
            };

            await _db.Environments.AddAsync(newEnvi);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Model.Framework_4M_1E.Environment>> GetEnvironmentByHeaderId(int headerId)
        {
            return await _db.Environments.Where(e => e.HeaderId == headerId).ToListAsync();
        }

        public async Task<IEnumerable<Output>> GetOutputByHeaderId(int headerId)
        {
            return await _db.Outputs.Where(e => e.HeaderId == headerId).ToListAsync();
        }

        public async Task FinalizeHeader(int headerId)
        {
            var h = await _db.M4EHeaders.FindAsync(headerId);
            h.Finalized = true;
            h.FinalizedDate = DateTime.Now;

            await _db.SaveChangesAsync();
        }

        public async Task<bool> isFinalized(int headerId)
        {
            return await _db.M4EHeaders.AnyAsync(e => e.HeaderId == headerId && e.Finalized == true);
        }
    }
}
