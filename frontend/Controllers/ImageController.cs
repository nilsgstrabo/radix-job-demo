using System.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.StaticFiles;

namespace frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public ImageController(IConfiguration configuration, ILogger<ImageController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("{imageId}")]
        public IActionResult GetTask(int imageId)
        {
            try
            {
                var path = _configuration["COMPUTE_IMAGE_PATH"];
                string fileName = imageId.ToString() + ".png";
                string imgPath = Path.Join(path, fileName);
                
                if (!System.IO.File.Exists(imgPath))
                {
                    return NotFound();
                }
                
                string mimeType;
                if (new FileExtensionContentTypeProvider().TryGetContentType(fileName, out mimeType) == false)
                {
                    mimeType = "application/octet-stream";
                }

                return File(new System.IO.FileStream(imgPath, FileMode.Open, FileAccess.Read), mimeType);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }

        }
    }
}