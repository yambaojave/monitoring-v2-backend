using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model;
using Monitoring4M1Ev2.Model.Matrix;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        private readonly IMatrixService _matrixService;

        public MatrixController(IMatrixService matrixService)
        {
            _matrixService = matrixService;
        }

        [HttpGet]
        public ActionResult GetProductionModels()
        {
            return Ok(_matrixService.GetProductionModels());
        }

        [HttpGet("process/{model}")]
        public ActionResult<Dictionary<string, string[]>> GetModelProcessOperation(string model)
        {
            if (!_matrixService.ModelExisting(model))
            {
                return NotFound(new { error = $"{model} does not yet exists, please add to operation matrix." });
            }
            return Ok(_matrixService.GetModelProcessOperation(model));
        }

        [HttpPost("model")]
        public ActionResult PostProductionModel(ProductionModelDto dto)
        {
            try
            {
                ActionResult conflictResult = CheckForConflicts(dto, "MODELS");

                if (conflictResult != null)
                {
                    return conflictResult;
                }

                return Created("model", _matrixService.PostProductionModel(dto));
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /*
         *  UNDER CHECKING IF TO BE USE OR NOT
         *  
         */
        [HttpPut("model/{id}")]
        public ActionResult PutProductionModel(ProductionModelDto dto, int id)
        {
            try
            {
                ActionResult conflictResult = CheckForConflicts(dto, "MODELS");

                if (conflictResult != null)
                {
                    return conflictResult;
                }

                _matrixService.UpdateProductionModel(dto, id, "");
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("model/{id}/status")]
        public ActionResult PutProductionModelStatus(int id)
        {
            try
            {
                _matrixService.UpdateProductionModel(null, id, "active");
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("wi")]
        public ActionResult PostWiMatrix(WIMatrixDto dto)
        {
            try
            {
                ActionResult conflictResult = CheckForConflicts(dto, "WI");

                if (conflictResult != null)
                {
                    return conflictResult;
                }

                return Created("wi", _matrixService.PostWIMatrix(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("wi/{id}")]
        public ActionResult PutWiMatrix(WIMatrixDto dto, int id)
        {
            try
            {
                ActionResult conflictResult = CheckForConflicts(dto, "WI");

                if (conflictResult != null)
                {
                    return conflictResult;
                }

                _matrixService.UpdateWIMatrix(dto, id, "");
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("wi/{id}/status")]
        public ActionResult PutWiMatrixResult(int id)
        {
            try
            {
                _matrixService.UpdateWIMatrix(null, id, "active");
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("process")]
        public ActionResult PostOperationProcess(OperationProcessDto dto)
        {
            try
            {
                //ActionResult conflictResult = CheckForConflicts(dto, "PROCESS");

                //if (conflictResult != null)
                //{
                //    return conflictResult;
                //}
                return Created("process", _matrixService.PostOperationProcess(dto));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("process/{id}")]
        public ActionResult PutOperationProcess(OperationProcessDto dto, int id)
        {
            try
            {
                //ActionResult conflictResult = CheckForConflicts(dto, "PROCESS");

                //if(conflictResult != null)
                //{
                //    return conflictResult;
                //}

                _matrixService.UpdateOperationProcess(dto, id, "");
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("process/{id}/status")]
        public ActionResult PutOperationProcessStatus(int id)
        {
            try
            {
                _matrixService.UpdateOperationProcess(null, id, "active");
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        private ActionResult CheckForConflicts(object dto, string table)
        {

            string description = getPropertyName(dto);
            if (Helpers.HasNullProperty(dto))
            {
                return Conflict(new { error = "Please complete all the fields." });
            }
            if (_matrixService.DuplicateInputChecking(dto, table))
            {
                return Conflict(new { error = $"{description} already exists. Kindly check your inputs." });
            }

            return null;
        }

        private string getPropertyName(object obj)
        {
            string[] arrayPropertyName = { "ModelName", "ControlNumber", "OperationName" };
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach(PropertyInfo property in properties)
            {
                if (arrayPropertyName.Contains(property.Name))
                {
                    foreach(string arr in arrayPropertyName)
                    {
                        if(arr == property.Name)
                        {
                            string description = obj.GetType().GetProperty(arr).GetValue(obj).ToString();
                            return description;
                        }
                    }
                }
            }

            return null;
        } 
        
    }
}