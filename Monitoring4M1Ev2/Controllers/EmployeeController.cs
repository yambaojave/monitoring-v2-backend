using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _eService;

        public EmployeeController(IEmployeeService eService)
        {
            _eService = eService;
        }

        [HttpGet("{emplId}")]
        public ActionResult GetEmployeeDetail(string emplId)
        {
            if (!_eService.IsValidEmployeeFormat(emplId))
            {
                return Conflict(new { error = "Employee ID format invalid." });
            }

            var details = _eService.GetDetails(emplId);

            if(details == null)
            {
                return NotFound(new { error = $"No Employee Id {emplId} has been found." });
            }

            return Ok(details);
        }

    }
}