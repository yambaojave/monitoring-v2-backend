using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.Barcode;

namespace Monitoring4M1Ev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        private readonly IBarcodeService _bcService;

        public BarcodeController(IBarcodeService bcService)
        {
            _bcService = bcService;
        }

        [HttpGet("workgroup/{id}/{output}")]
        public ActionResult GetOperations(int id, string output)
        {
            // Getting of row details in workgroup 
            string[] result = null;
            string[] operations = { "operators", "templates_machines" };

            var workgroup = (B2WORKGROUP)null;
            var wgDetail = (WorkgroupDetail)null;

            switch (output)
            {
                case "operators" :
                    result = _bcService.GetWorkGroupOperators(id);
                    return Ok(result);
                case "templates_machines" :
                    result = _bcService.GetWorkGroupMachineTemplate(id);
                    return Ok(result);
                case "header":
                    workgroup = _bcService.GetWorkGroup(id);
                    return Ok(workgroup);
                case "full_details":
                    wgDetail = _bcService.GetWholeWorkGroupDetails(id);
                    return Ok(wgDetail);
            }

            return NotFound(new { error = "No output found." });
        }

        // Getting of the latest workgroup created from barcode system
        [HttpGet("latestwg/{line}")]
        public ActionResult<B2WORKGROUP> GetLatestWG(string line)
        {
            return Ok(_bcService.GetLatestWorkGroupByLine(line));
        }

        [HttpGet("item/{name}")]
        public ActionResult GetItemDescription(string name)
        {
            var details = _bcService.GetItemDescription(name);

            if (details == null)
                return NotFound(new { error = "No Item Found." });

            return Ok(details);
        }

    }
}