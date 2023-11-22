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
    [Host("*:6000")]
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

        [HttpPost("job")]
        public IActionResult PostJobStatus([FromBody] BatchEvent batchStatus)
        {
            _logger.LogInformation("Received POST job notification");
            return StatusCode(200);
        }
    }
}
