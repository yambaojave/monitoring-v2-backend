using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Operator;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _operatorService;

        public OperatorController(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpGet("all")]
        public ActionResult GetAllOperator()
        {
            return Ok(_operatorService.GetAllOperators());
        }

        [HttpGet("{data}")]
        public ActionResult GetOperator(string data)
        {
            if (!_operatorService.CheckDataExists(data, "OPERATOR"))
            {
                return NotFound(new { error = $"No operator with Employee ID {data} found." });
            }

            return Ok(_operatorService.GetOperator(data.ToString()));
        }

        [HttpPost]
        public ActionResult PostOperator([FromBody] OperatorDetailDto dto)
        {
            if(_operatorService.CheckDataExists(dto.OperatorEmployeeId, "OPERATOR"))
            {
                return Conflict(new { error = $"Employee {dto.OperatorEmployeeId} already exists in operator module." });
            }

            var newOperator = _operatorService.AddOperator(dto);
            return Ok(newOperator);
        }

        [HttpPost("qualification")]
        public ActionResult PostQualification([FromBody] OperatorQualificationDto dto)
        {
            //if (_operatorService.CheckDataExists(dto.OperatorDetailId, "QUALIFICATION"))
            //{
            //    return Conflict(new { error = $"Employee {dto.OperatorEmployeeId} already exists in operator module." });
            //}

            var newQualification = _operatorService.AddOperatorQualification(dto);
            //_operatorService.OperatorUpdateTime(dto.OperatorDetailId);
            return Ok(newQualification);
        } 

        [HttpPost("{id}/answer")]
        public ActionResult PostAnswer(int id, [FromBody] string answer)
        {
            if (_operatorService.CheckDataExists(id, "ANSWER"))
            {
                return Conflict(new { error = $"Employee qualification sheet already has answer." });
            }

            _operatorService.AddOperatorSafetyAnswer(answer, id);
            return Ok();
        }

        [HttpPost("evaluation")]
        public ActionResult PostEvaluation([FromBody] CombinedEvaluation dto)
        {
            _operatorService.AddUpdateEvaluation(dto.EvaluationDto, dto.ItemEvaluationDto, dto.process, dto.evalId, dto.qualifyId);
            return Ok();
        }

        [HttpPut("evaluation")]
        public ActionResult PutEvaluation([FromBody] CombinedEvaluation dto)
        {
            _operatorService.AddUpdateEvaluation(dto.EvaluationDto, dto.ItemEvaluationDto, dto.process, dto.evalId, dto.qualifyId);
            return Ok();
        }


    }
}