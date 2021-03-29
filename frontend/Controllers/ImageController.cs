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
using AFP.Web.Hubs;
using System.Security.Cryptography;

namespace frontend.Controllers
{
    public class ImageChangedRequest
    {
        public MandelbrotCoord Top { get; set; }
        public MandelbrotCoord Bottom { get; set; }
    }

    public class ImagePostData
    {
        public string Data { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly INotificationHubService _hub;
        public ImageController(IConfiguration configuration, ILogger<ImageController> logger, INotificationHubService hub)
        {
            _logger = logger;
            _configuration = configuration;
            _hub = hub;
        }


        [HttpGet("{imageId}")]
        public IActionResult GetImage(int imageId)
        {
            _logger.LogInformation(0, "********* Logging Headers **********");
            _logger.LogInformation(
                0,
                this.Request.Headers.ToList().Aggregate("", (s, h) => s + h.Key + ": " + h.Value.ToString().Substring(0, Math.Min(10, h.Value.ToString().Length)) + Environment.NewLine)
            );
            _logger.LogInformation(0, "********* Done **********");

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

        [HttpGet("{imageId}/_exists")]
        public IActionResult GetImageExists(int imageId)
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

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("{imageId}")]
        public async Task<IActionResult> ImageChanged([FromRoute] int imageId, [FromBody] ImageChangedRequest request)
        {
            try
            {
                await _hub?.NotifyImageChanged(new ImageChanged { ImageId = imageId, Top = request.Top, Bottom = request.Bottom });
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("{imageId}/data")]
        public IActionResult ImageData([FromRoute] int imageId, [FromBody] ImagePostData imageData)
        {
            try
            {
                _logger.LogInformation("Received request for new image with data length {0}", imageData.Data.Length);
                var path = _configuration["COMPUTE_IMAGE_PATH"];
                var imageBytes = System.Convert.FromBase64String(imageData.Data);
                using (var ms = new MemoryStream(imageBytes))
                {
                    string fileName = imageId.ToString() + ".png";
                    string imgPath = Path.Join(path, fileName);
                    using (var fs = new System.IO.FileStream(imgPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        ms.CopyTo(fs);
                    }

                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500);
            }
        }

    }
}