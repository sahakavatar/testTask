using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task.Models;
using Task.Models.Requests;
using Task.Services;

namespace Task.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImageServiceController : ControllerBase
    {
        private readonly ILogger<ImageProcessor> _logger;

        public ImageServiceController(ILogger<ImageProcessor> logger)
        {
            _logger = logger;
        }

        [HttpPost("process")]
        public IActionResult ProcessImages([FromBody] ImageRequest request)
        {
            var processor = new ImageProcessor(_logger);
            var result = processor.Process(request);

            return Ok(result);
        }
    }
}
