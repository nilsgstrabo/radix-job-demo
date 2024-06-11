using System.Net.WebSockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RadixJobClient.Model;
using System.Runtime.Versioning;
using Microsoft.Extensions.Hosting;
using frontend.Hubs;
using Microsoft.Data.SqlClient;

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

        public int Sleep { get; set; }
        public bool Fail { get; set; }

        public string? CustomJobName { get; set; }

        public int BackoffLimit { get; set; }
        public long TimelimitSeconds { get; set; }
        public int JobCount { get; set; }
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
    public class Compute1Controller : ComputeControllerBase {
        public Compute1Controller(IConfiguration configuration, [FromKeyedServices("compute1")] IComputeService computeService,INotificationHubService hub, ILogger<Compute1Controller> logger)
        :base(configuration, computeService, hub, logger)
        {}
    }

    [ApiController]
    [Route("api/[controller]")]
    public class Compute2Controller : ComputeControllerBase {
        public Compute2Controller(IConfiguration configuration, [FromKeyedServices("compute2")] IComputeService computeService,INotificationHubService hub, ILogger<Compute2Controller> logger)
        :base(configuration, computeService, hub, logger)
        {}
    }


    // [Host("*:5000")]
    public abstract class ComputeControllerBase : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IComputeService _computeService;
        private readonly INotificationHubService _hub;
        private readonly IConfiguration _configuration;

        public ComputeControllerBase(IConfiguration configuration, IComputeService computeService,INotificationHubService hub, ILogger logger)
        {
            _logger = logger;
            _computeService = computeService;
            _hub=hub;
            _configuration=configuration;
        }

        [HttpGet("jobs")]
        public async Task<ActionResult<List<JobStatus>>> GetJobs()
        {
            try
            {
                await _hub.NotifyTimeChanged(DateTime.Now.ToString());
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

        [HttpPost("batches")]
        public async Task<ActionResult<BatchStatus>> CreateBatch([FromBody] JobRequest request)
        {
            try
            {
                var job = await _computeService.CreateBatch(request);
                return job;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("kill")]
        public IActionResult Kill([FromServices] IHostApplicationLifetime app)
        {
            try
            {
                app.StopApplication();
                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }
    }
}
