using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Framework_4M_1E;
using Monitoring4M1Ev2.Model.Plan;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class M4EController : ControllerBase
    {
        private readonly IM4EService _m4eService;
        private readonly IPlanService _planService;
        private readonly IBarcodeService _barcodeService;

        public M4EController(IM4EService m4eService, IPlanService planService, IBarcodeService barcodeService)
        {
            _m4eService = m4eService;
            _planService = planService;
            _barcodeService = barcodeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHeader([FromBody] M4EHeaderDto dto)
        {
            try
            {
                var plan = await _planService.ExistingPlanHeader(dto);
                if(plan == null)
                {
                    throw new Exception($"{dto.Model} does not have an existing plan.");
                }

                if (await _m4eService.WorkGroupExist(dto.WorkGroupId))
                {
                    throw new Exception("Work Group already exist.");
                }

                var wgDetail = _barcodeService.GetWholeWorkGroupDetails(dto.WorkGroupId);
                
                // Monitoring header creation
                var newHeader = await _m4eService.CreateHeader(dto, plan.PlanHeaderId, plan.Type);


                int newHeaderId = newHeader.HeaderId;
                string actualNotFoundStatus = "PLAN MISSING";
                string planNotFoundStatus = "ACTUAL MISSING";
                await _planService.UpdateHeaderUsedStatus(plan.PlanHeaderId);

                // PLAN MOVEMENT OF DATA
                foreach (PlanDetail detail in plan.PlanDetails)
                {
                    
                    if(await _m4eService.ManExist(detail.Operator, newHeaderId))
                    {
                        continue;
                    }

                    var newMan = new ManDto
                    {
                        EmployeeId = detail.Operator,
                        Status = detail.Condition == "GOOD" && wgDetail.Operators.Contains(detail.Operator) ? "OK" : planNotFoundStatus,
                        HeaderId = newHeaderId
                    };

                    await _m4eService.AddManDetails(newMan);
                }

                // ACTUAL OPERATOR MOVEMENT
                foreach(string wgOperators in wgDetail.Operators)
                {
                    if (await _m4eService.ManExist(wgOperators, newHeaderId))
                    {
                        continue;
                    }

                    var newMan = new ManDto
                    {
                        EmployeeId = wgOperators,
                        Status = actualNotFoundStatus,
                        HeaderId = newHeaderId
                    };

                    await _m4eService.AddManDetails(newMan);
                }


                // PLAN MACHINE MOVEMENT
                foreach(PlanDetail detail in plan.PlanDetails)
                {
                    string[] machinesArray = detail.Machines.Split(", ");
                    foreach(string machine in machinesArray)
                    {
                        if (await _m4eService.MachineExist(machine, newHeaderId))
                        {
                            continue;
                        }

                        var newMachine = new MachineDto
                        {
                            MachineName = machine,
                            Status = detail.Condition == "GOOD" && wgDetail.MachinesAndTemplates.Contains(machine) ? "OK" : planNotFoundStatus,
                            HeaderId = newHeaderId
                        };

                        await _m4eService.AddMachineDetails(newMachine);
                    }
                }

                // ACTUAL MACHINE MOVEMENT
                foreach(string wgMachines in wgDetail.MachinesAndTemplates)
                {
                    if(await _m4eService.MachineExist(wgMachines, newHeaderId))
                    {
                        continue;
                    }

                    var newMachine = new MachineDto
                    {
                        MachineName = wgMachines,
                        Status = actualNotFoundStatus,
                        HeaderId = newHeaderId
                    };

                    await _m4eService.AddMachineDetails(newMachine);
                }


                // METHOD TO BE ADDED AFTER ADDING METHOD IN TPROMS





                // MATERIAL ACTUAL
                var bomMaterials = _barcodeService.GetAllBomRelation(dto.Model);
                foreach(var bom in bomMaterials)
                {
                    var newMaterial = new MaterialDto
                    {
                        Component = bom.ComponentItem,
                        Description = bom.Description,
                        Type = "BOM",
                        Status = "OK",
                        HeaderId = newHeaderId
                    };

                    await _m4eService.AddMaterial(newMaterial);
                }



                Dictionary<int, int[]> shiftValue = new Dictionary<int, int[]>();

                shiftValue.Add(2, new int[] { 8, 6 });
                shiftValue.Add(3, new int[] { 12, 6 });
                shiftValue.Add(4, new int[] { 8, 14 });
                shiftValue.Add(5, new int[] { 12, 18 });
                shiftValue.Add(6, new int[] { 8, 22 });



                if(shiftValue.TryGetValue(newHeader.ShiftCode, out int[] values))
                {
                    int hours = values[0];
                    int timeStart = values[1];
                    int finalHour = hours + timeStart;
                    int outputPerHour = 30;
                    int initialCount = 1;

                    for(int i = timeStart + 1; i <= finalHour; i++)
                    {
                        string initialStart = i < 10 ? "0" : "";
                        string time = $"{initialStart}{i}:00";

                        if(i > 24)
                        {
                            time = $"0{i - 24}:00";
                        }


                        var newOutput = new OutputDto
                        {
                            TimeRange = time,
                            Plan = outputPerHour * initialCount,
                            Actual = 0,
                            Difference = 0,
                            HeaderId = newHeaderId,
                            Updated = initialCount == 1 ? false : true
                        };

                        await _m4eService.AddOutput(newOutput);
                        initialCount++;
                    }

                }

                /*
                 *  CHECK IF A PLAN DOES EXISTS IT MAY BE NORMAL/SUDDEN 
                 *  IF DOES NOT EXISTS RETURN AN ERROR
                 *  
                 *  CREATE A PLAN FIRST
                 *  UPDATE THE NEWLY CREATED PLAN WITH THE EXISTING PLAN
                 *  
                 *  CREATE A NEW LIST OF DATA FOR ACTUAL MONITORING BASE ON TPROMS DATA AND PLAN DATA
                 *  ADD STATUS CONDITION PER ITEM
                 *  
                 *  
                 */


                return Created("header", newHeader);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("headers")]
        public async Task<IActionResult> GetHeaderByLines([FromBody] LineRequest lineRequest)
        {
            try
            {
                string[] arrayLines = lineRequest.Lines;
                return Ok(await _m4eService.GetAllHeaderByUserLinesAsync(arrayLines));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


        [HttpGet("man/{id}")]
        public async Task<IActionResult> GetManByHeaderIdAsync(int id)
        {
            try
            {
                return Ok(await _m4eService.GetManByHeaderIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("machine/{id}")]
        public async Task<IActionResult> GetMachineByIdAsync(int id)
        {
            try
            {
                return Ok(await _m4eService.GetMachineByHeaderIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("material/{id}")]
        public async Task<IActionResult> GetMaterialByIdAsync(int id)
        {
            try
            {
                return Ok(await _m4eService.GetMaterialByHeaderIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("output/{id}")]
        public async Task<IActionResult> GetOutputByIdAsync(int id)
        {
            try
            {
                var outputs = await _m4eService.GetOutputByHeaderIdAsync(id);
                Dictionary<string, object> newFormatOutput = new Dictionary<string, object>();

                foreach(var output in outputs)
                {
                    newFormatOutput.Add(output.TimeRange, new {
                        output.Plan,
                        output.Actual,
                        output.Difference,
                        output.OutputId,
                        output.UserInput,
                        output.Updated,
                        output.Remarks,
                        output.UpdateDate
                    });
                }

                return Ok(newFormatOutput);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


        [HttpPut("output")]
        public async Task<IActionResult> PutOutputById(OutputCompute compute)
        {
            try
            {
                await _m4eService.UpdateOutputById(compute);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


        [HttpGet("mainHeader/{line}")]
        public async Task<IActionResult> GetLatestHeaderByLine(string line)
        {
            try
            {
                return Ok(await _m4eService.GetLatestWorkingHeaderByLine(line));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


        [HttpGet("group-report/{headerId}")]
        public async Task<IActionResult> GetHeaderGroupReport(int headerId)
        {
            try
            {
                var hDetails = await _m4eService.GetHeaderById(headerId);
                var planDetails = await _planService.GetAllDetailByIdAsync(hDetails.PlanId);
                var wg = _barcodeService.GetWgDetails(hDetails.WorkGroupId);


                // New List for comparing with work group details
                List<PlanGroupDetail> newPDetails = new List<PlanGroupDetail>();


                foreach(var d in planDetails)
                {
                    string[] machineArray = d.Machines.Split(", ");

                    foreach (string machine in machineArray)
                    {
                        newPDetails.Add(new PlanGroupDetail
                        {
                            Operator = d.Operator,
                            Process = d.Process,
                            ControlNumber = d.ControlNumber,
                            Machine = machine,
                            Condition = d.Condition
                        });
                    }
                }


                List<GroupM4EData> mgd = new List<GroupM4EData>();

                foreach (PlanGroupDetail pd in newPDetails)
                {
                    // Check for MACHINE, OPERATOR

                    var wgCheck = wg.FirstOrDefault(e => e.machineCode == pd.Machine && e.operatorCode == pd.Operator);

                    if(wgCheck != null)
                    {
                        mgd.Add(new GroupM4EData
                        {
                            Operator = pd.Operator,
                            Machine = pd.Machine,
                            Process = pd.Process,
                            ControlNumber = pd.ControlNumber,
                            Category = "PLAN",
                            Status = "OK"
                        });

                        mgd.Add(new GroupM4EData
                        {
                            Operator = pd.Operator,
                            Machine = pd.Machine,
                            Process = "",
                            ControlNumber = "",
                            Category = "ACTUAL",
                            Status = "OK"
                        });
                    }

                    else
                    {
                        mgd.Add(new GroupM4EData
                        {
                            Operator = pd.Operator,
                            Machine = pd.Machine,
                            Process = pd.Process,
                            ControlNumber = pd.ControlNumber,
                            Category = "PLAN",
                            Status = "ACTUAL MISSING"
                        });
                    }

                    
                }

                foreach(var g in wg)
                {
                    var details = mgd.FirstOrDefault(e => e.Operator == g.operatorCode && e.Machine == g.machineCode);
                    if(details == null)
                    {
                        mgd.Add(new GroupM4EData
                        {
                            Operator = g.operatorCode,
                            Machine = g.machineCode,
                            Process = "",
                            ControlNumber = "",
                            Category = "ACTUAL",
                            Status = "PLAN MISSING"
                        });
                    }
                }


                return Ok(mgd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("man/replacementop")]
        public async Task<IActionResult> PutOpReplacement(ReplacementDto dto)
        {
            try
            {
                await _m4eService.UpdateReplacement(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


        [HttpGet("man/detail/{id}")]
        public async Task<IActionResult> GetManByIdAsync(int id)
        {
            try
            {
                return Ok(await _m4eService.GetManDetailById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("environment/{headerId}")]
        public async Task<IActionResult> GetEnvironment(int headerId)
        {
            try
            {
                return Ok(await _m4eService.GetEnvironmentByHeaderId(headerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("environment")]
        public async Task<IActionResult> AddEnvironment(EnvironmentDto dto)
        {
            try
            {
                await _m4eService.AddEnvironment(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("output-report/{headerId}")]
        public async Task<IActionResult> GetOutputByHeaderId(int headerId)
        {
            try
            {
                return Ok(await _m4eService.GetOutputByHeaderId(headerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("finalized/{headerId}")]
        public async Task<IActionResult> FinalizeHeader(int headerId)
        {
            try
            {
                await _m4eService.FinalizeHeader(headerId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

    }
}


