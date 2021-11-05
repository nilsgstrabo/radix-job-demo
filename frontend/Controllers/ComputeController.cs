using System.Net.WebSockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RadixJobClient.Model;
using System.Runtime.Versioning;

namespace frontend.Controllers
{

public enum JobResourceEnum {
    Default=0,
    Low=1,
    Medium=2,
    High=3,
    TooLow=4,
}

    public class JobRequest
    {
        public int ImageId { get; set; }
        public MandelbrotWindow MandelbrotWindow { get; set; }
        public JobResourceEnum Memory { get; set; }
        public JobResourceEnum Cpu { get; set; }
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
        public async Task<ActionResult<List<JobStatus>>> GetJobs()
        {
            try
            {
                return await _computeService.GetJobs();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            
        }

        [HttpPost("jobs")]
        public async Task<ActionResult<JobStatus>> CreateJob([FromBody] JobRequest request)
        {
            try
            {
                var job = await _computeService.CreateJob(request);
                return job;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
