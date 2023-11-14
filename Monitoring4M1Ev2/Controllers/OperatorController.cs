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

        [HttpGet("{id}")]
        public ActionResult GetOperator(int id)
        {
            return Ok(_operatorService.GetOperator(id));
        }

        [HttpPost]
        public ActionResult PostOperator([FromBody] OperatorDetailDto dto)
        {
            _operatorService.AddOperator(dto);
            return Ok();
        }

        [HttpPost("qualification")]
        public ActionResult PostQualification([FromBody] OperatorQualificationDto dto)
        {
            _operatorService.AddOperatorQualification(dto);
            return Ok();
        } 

        [HttpPost("{id}/answer")]
        public ActionResult PostAnswer(int id, [FromBody] string answer)
        {
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