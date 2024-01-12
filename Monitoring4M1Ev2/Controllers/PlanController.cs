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

        public PlanController(IPlanService planService)
        {
            _planService = planService;
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

        [HttpPost("header")]
        public async Task<IActionResult> CreateHeaderAsync([FromBody] PlanHeaderDto dto)
        {
            try
            {
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
    }
}