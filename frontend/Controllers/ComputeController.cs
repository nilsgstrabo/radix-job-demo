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
        private readonly INotificationHubService _hub;
        private readonly IConfiguration _configuration;

        public ComputeController(IConfiguration configuration, IComputeService computeService,INotificationHubService hub, ILogger<ComputeController> logger)
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
                var connStr = $"Server={_configuration["SQL_SERVER_NAME"]}; Authentication=Active Directory Managed Identity; Encrypt=True; Database={_configuration["SQL_DATABASE_NAME"]}";
                using(SqlConnection conn = new SqlConnection(connStr)) {
                    conn.Open();
                    using(SqlCommand cmd=new SqlCommand("select count(1) as cnt from dbo.Products", conn)) {
                        var v=cmd.ExecuteScalar();
                        _logger.LogInformation("Got {0}", v);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

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
