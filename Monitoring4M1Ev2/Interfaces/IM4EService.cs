using Monitoring4M1Ev2.Model.Framework_4M_1E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IM4EService
    {
        Task<IEnumerable<M4EHeader>> GetAllHeaderByUserLinesAsync(string[] lines);

        Task<IEnumerable<Man>> GetManByHeaderIdAsync(int id);

        Task<IEnumerable<Machine>> GetMachineByHeaderIdAsync(int id);

        Task<IEnumerable<Material>> GetMaterialByHeaderIdAsync(int id);

        Task<IEnumerable<Output>> GetOutputByHeaderIdAsync(int id);

        Task<M4EHeader> GetLatestWorkingHeaderByLine(string line);


        // HEADER

        Task<M4EHeader> CreateHeader(M4EHeaderDto dto, int planId, string type);
        Task<bool> WorkGroupExist(int workgroupId);
        Task<M4EHeader> GetHeaderById(int headerId);

        // MAN

        Task AddManDetails(ManDto dto);
        Task<bool> ManExist(string OperatorId, int newHeaderId);
        Task UpdateReplacement(ReplacementDto dto);
        Task<Man> GetManDetailById(int manId);

        // MACHINE

        Task AddMachineDetails(MachineDto dto);
        Task<bool> MachineExist(string machine, int newHeaderId);


        // MATERIAL
        Task AddMaterial(MaterialDto dto);




        // OUTPUTS
        Task AddOutput(OutputDto dto);
        Task UpdateOutputById(OutputCompute compute);
        Task<IEnumerable<Output>> GetOutputByHeaderId(int headerId);


        // ENVIRONMENT
        Task AddEnvironment(EnvironmentDto dto);
        Task<IEnumerable<Model.Framework_4M_1E.Environment>> GetEnvironmentByHeaderId(int headerId);


        // FINALIZED
        Task FinalizeHeader(int headerId);
        Task<bool> isFinalized(int headerId);

    }
}
