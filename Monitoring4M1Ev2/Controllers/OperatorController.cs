using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IMatrixService _matrixService;
        private readonly IM4EService _m4EService;

        public OperatorController(IOperatorService operatorService, IMatrixService matrixService, IM4EService m4EService)
        {
            _operatorService = operatorService;
            _matrixService = matrixService;
            _m4EService = m4EService;
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

        [HttpGet("{data}/current")]
        public ActionResult GetCurrentQualification(string data)
        {
            return Ok(_operatorService.GetCurrentQualification(data));
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
        [Authorize(Roles = "ADMIN, LEADER")]
        public ActionResult PostQualification([FromBody] OperatorQualificationDto dto)
        {
            //if (_operatorService.CheckDataExists(dto.OperatorDetailId, "QUALIFICATION"))
            //{
            //    return Conflict(new { error = $"Employee {dto.OperatorEmployeeId} already exists in operator module." });
            //}

            var newQualification = _operatorService.AddOperatorQualification(dto);
            _operatorService.OperatorUpdateTime(dto.OperatorDetailId);
            return Ok(newQualification);
        } 

        [HttpPut("qualification/{id}")]
        public ActionResult PutQualificationById(int id, [FromBody] OperatorQualificationDto dto)
        {
            _operatorService.UpdateOperatorQualificationById(id, dto);
            return NoContent();
        }

        [HttpPost("answer/{id}")]
        public ActionResult PostAnswer(int id, [FromBody] string answer)
        {
            if (_operatorService.CheckDataExists(id, "ANSWER"))
            {
                return Conflict(new { error = $"Employee qualification sheet already has answer." });
            }

            var newAnswer = _operatorService.AddOperatorSafetyAnswer(answer, id);
            return Ok(newAnswer);
        }

        [HttpPut("answer/{id}")]
        public ActionResult PutAnswerById(int id, [FromBody] string answer)
        {
            _operatorService.UpdateOperatorSafetyAnswerById(answer, id);
            return NoContent();
        }

        [HttpPost("evaluation")]
        public ActionResult PostEvaluation([FromBody] EvaluationDto dto)
        {
            var newEvaluation = _operatorService.AddEvaluation(dto);
            return Ok(newEvaluation);
        }

        [HttpPut("evaluation")]
        public ActionResult PutEvaluation([FromBody] UpdateEvaluationDto dto)
        {
            _operatorService.UpdateEvaluation(dto.ItemEvaluationDto, dto.EvaluationId);
            return Ok();
        }

        [HttpDelete("evaluation/{id}")]
        public ActionResult DeleteEvaluation(int id)
        {
            _operatorService.DeleteEvaluation(id);
            return NoContent();
        }

        [HttpGet("pcsresult/{evalId}")]
        public ActionResult GetPcsResultByEvalId(int evalId)
        {
            return Ok(_operatorService.GetOperatorQualificationPcsByEvalId(evalId));
        }

        [HttpPost("pcsresult")]
        public ActionResult PostPcsResult([FromBody] OperatorEvaluationPcsDto dto)
        {
            var newPcsResult = _operatorService.AddPcsResult(dto);

            return Ok(newPcsResult);
        }

        [HttpPut("finalize_assesment/{id}")]
        public ActionResult PutQualificationOverallAssessment(int id)
        {
            bool result = _operatorService.EvaluateAssessment(id);

            if (result)
            {
                return Ok(new { result = "Finalize done." } );
            }

            return Conflict(new { error = "Please complete the evaluation." });
        }


        [HttpGet("model/{model}")]
        public ActionResult GetOperatorByModel(string model)
        {
            try
            {
                IEnumerable<object> ByModels = _operatorService.GetOperatorByModel(model);
                var myMatrix = _matrixService.GetProductionModelByName(model);


                var myDictionary = new Dictionary<string, object[]>();

                foreach (var m in ByModels)
                {
                    PropertyInfo currentOperator = m.GetType().GetProperty("OperatorEmployeeId");
                    PropertyInfo opProcess = m.GetType().GetProperty("Process");
                    PropertyInfo reassessment = m.GetType().GetProperty("ForReassessment");
                    object operatorId = currentOperator.GetValue(m);
                    object processArray = opProcess.GetValue(m);
                    object reassessmentValue = reassessment.GetValue(m);

                    var objectList = new List<ExpandoObject>();

                    foreach(var item in (Array)processArray)
                    {
                        var machines = myMatrix.WIMatrices.Where(e => e.ProcessNumber == item.ToString()).FirstOrDefault();
                        var operations = machines.OperationProcesses.Select(e => e.OperationName).ToArray();

                        dynamic newObject = new ExpandoObject();

                        newObject.machines = operations;
                        newObject.process = item;
                        newObject.controlNumber = machines.ControlNumber;
                        newObject.reAssessment = reassessmentValue;

                        objectList.Add(newObject);
                    }

                    object[] objectsArray = objectList.ToArray();

                    if (myDictionary.ContainsKey(operatorId.ToString()))
                    {
                        //object[] existingArray = myDictionary["O-0003242"];
                        //object[] newArray = new object[existingArray.Length + 1];
                        //Array.Copy(existingArray, newArray, existingArray.Length);
                        //newArray[existingArray.Length] = objectsArray;


                        //myDictionary["O-0003242"] = newArray;

                        object[] existingArray = myDictionary[operatorId.ToString()];
                        var existingList = existingArray.ToList();

                        foreach(var item in objectList)
                        {
                            existingList.Insert(1, item);
                        }

                        object[] newArray = existingList.ToArray();
                        myDictionary[operatorId.ToString()] = newArray;
                    }
                    else
                    {
                        myDictionary.Add(operatorId.ToString(), objectsArray);
                    }

                }




                return Ok(myDictionary);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        [HttpPost("opcheck")]
        public async Task<ActionResult> OperatorCheck(OperatorCheckDto dto)
        {
            try
            {
                var opExists = _operatorService.GetOperatorById(dto.OperatorEmployeeId);
                if(opExists == null)
                {
                    return NotFound(new { error = $"{dto.OperatorEmployeeId} not found." } );
                }

                var hd = await _m4EService.GetHeaderById(dto.HeaderId);
                var qualifications = _operatorService.GetQualification(opExists.OperatorDetailId, hd.Model);

                if(qualifications.Count == 0)
                {
                    return NotFound(new { error = $"{dto.OperatorEmployeeId} is not qualified for this model {hd.Model}." });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }


    }
}