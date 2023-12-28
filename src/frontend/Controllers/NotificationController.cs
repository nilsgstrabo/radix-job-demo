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
    
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            
            _logger = logger;
        }

        [HttpGet("job")]
        public IActionResult GetJobs()
        {
            _logger.LogInformation("Received GET job notification");
            return StatusCode(200);
        }

        [Host("*:6001")]
        [HttpPost("compute1")]
        public async Task<IActionResult> PostCompute1Status()
        {
            try
            {
                var rdr=new StreamReader(this.Request.Body);
                string b=await rdr.ReadToEndAsync();
                _logger.LogInformation("Received POST job notification for compute on 6001");
                _logger.LogInformation(b);
                return StatusCode(200);    
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [Host("*:6002")]
        [HttpPost("compute2")]
        public async Task<IActionResult> PostCompute2Status()
        {
            try
            {
                var rdr=new StreamReader(this.Request.Body);
                string b=await rdr.ReadToEndAsync();
                _logger.LogInformation("Received POST job notification for compute2 on 6002");
                _logger.LogInformation(b);
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
