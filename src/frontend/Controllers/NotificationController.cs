﻿using System.Net.WebSockets;
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
using Newtonsoft.Json;




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
        public IActionResult PostCompute1Status()
        {
            try
            {
                var batch = GetBatchEvent();
                if(batch!=null) {
                    _logger.LogInformation("Received batch event for compute1 on 6001: {0} - {1}", batch.BatchName, batch.Status);
                } else {
                    _logger.LogWarning("unable to read batch event from request");
                }
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
        public IActionResult PostCompute2Status()
        {
            try
            {
                var batch = GetBatchEvent();
                if(batch!=null) {
                    _logger.LogInformation("Received batch event for compute2 on 6002: {0} - {1}", batch.BatchName, batch.Status);
                } else {
                    _logger.LogWarning("unable to read batch event from request");
                }
                return StatusCode(200);    
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        private BatchEvent? GetBatchEvent() {
            var rdr=new StreamReader(this.Request.Body);
            using(StreamReader sr = new StreamReader(this.Request.Body))
            using(JsonTextReader reader=new JsonTextReader(sr)) {
                return new JsonSerializer().Deserialize<BatchEvent>(reader);
            }
        }

    }
}
