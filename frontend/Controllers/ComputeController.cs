using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger<ComputeController> _logger;
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
    }
}
