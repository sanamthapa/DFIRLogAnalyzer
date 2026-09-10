using DFIR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFIR.Api.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileIngestionService _fileIngestionService;

        public FileUploadController(
            IFileIngestionService fileIngestionService)
        {
            _fileIngestionService = fileIngestionService;
        }

        [HttpPost("upload")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Upload(IFormFile file,CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest(new
                {
                    message = "Please provide a valid file."
                });
            }

            await using var stream = file.OpenReadStream();

            var events = await _fileIngestionService.ProcessAsync(
                stream,
                file.FileName,
                cancellationToken);

            return Ok(new
            {
                fileName = file.FileName,
                fileSize = file.Length,
                eventCount = events.Count(),
                events
            });
        }
    }
}