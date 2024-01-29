using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Plan;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;
        private readonly IMatrixService _matrixService;

        public PlanController(IPlanService planService, IMatrixService matrixService)
        {
            _planService = planService;
            _matrixService = matrixService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _planService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetAllDetailByIdAsync(int id)
        {
            try
            {
                return Ok(await _planService.GetAllDetailByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("header")]
        public async Task<IActionResult> CreateHeaderAsync([FromBody] PlanHeaderDto dto)
        {
            try
            {
                if (!_matrixService.ModelExisting(dto.Model))
                {
                    return NotFound(new { error = $"Model {dto.Model} does not exists. Kindly check matrix or whitespaces." });
                }

                return Created("header", await _planService.CreateHeaderAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("detail")]
        public async Task<IActionResult> CreateDetailAsync([FromBody] PlanDetailDto dto)
        {
            try
            {
                return Created("detail", await _planService.CreateDetailAsync(dto));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete("header/{id}")]
        public async Task<IActionResult> DeleteHeaderAsync(int id)
        {
            try
            {
                await _planService.DeleteHeaderAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete("detail/{id}")]
        public async Task<IActionResult> DeleteDetailASync(int id)
        {
            try
            {
                await _planService.DeleteDetailASync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("clone/{id}")]
        public async Task<IActionResult> ClonePlanAsync(int id)
        {
            try
            {
                var header = await _planService.GetHeaderByIdAsync(id);
                var dto = new PlanHeaderDto
                {
                    Model = header.Model,
                    Shift = header.Shift,
                    Line = header.Line,
                    PlanDate = DateTime.MinValue,
                    CreatedBy = 1
                };

                var cloneHeader = await _planService.CreateHeaderAsync(dto);

                var details = await _planService.GetAllDetailByIdAsync(id);

                var cloneDetails = await _planService.GetCloneNewDetails(details, header.Model);

                foreach(var clone in cloneDetails)
                {
                    var dtoDetail = new PlanDetailDto
                    {
                        Operator = clone.Operator,
                        Condition = clone.Condition,
                        Process = clone.Process,
                        ControlNumber = clone.ControlNumber,
                        Machines = clone.Machines,
                        PlanHeaderId = cloneHeader.PlanHeaderId
                    };

                    await _planService.CreateDetailAsync(dtoDetail);
                }


                return Created("clone", cloneHeader);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutHeaderById ([FromBody] PlanHeader planHeader)
        {
            try
            {
                if (!_matrixService.ModelExisting(planHeader.Model))
                {
                    return NotFound(new { error = $"Model {planHeader.Model} does not exists. Kindly check matrix or whitespaces." });
                }

                await _planService.UpdateHeaderById(planHeader);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}