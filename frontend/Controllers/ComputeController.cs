using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;

namespace frontend.Controllers
{

    public class JobRequest
    {
        public int ImageId { get; set; }
        public MandelbrotWindow MandelbrotWindow { get; set; }
    }

    public class MandelbrotCoord
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class MandelbrotWindow
    {
        public MandelbrotCoord Top { get; set; }
        public MandelbrotCoord Bottom { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IComputeService _computeService;

        public ComputeController(IComputeService computeService, ILogger<ComputeController> logger)
        {
            _logger = logger;
            _computeService = computeService;
        }



        [HttpGet("jobs")]
        public async Task GetJobs()
        {
            await _computeService.GetJobs();
        }

        [HttpPost("jobs")]
        public async Task<ActionResult<JobStatus>> CreateJob([FromBody] JobRequest request)
        {
            try
            {
                var job=await _computeService.CreateJob(request);
                return job;
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
