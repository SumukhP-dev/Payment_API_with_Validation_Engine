using Microsoft.AspNetCore.Mvc;
using PaymentApi.Models;
using PaymentApi.Services;
using PaymentProcessingApi.Services;
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Services;
using PaymentApi.Models;   // 👈 Add this namespace for FileUploadRequest

namespace PaymentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly S3Service _s3Service;

        public FilesController(S3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadRequest request)
        {
            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("File is empty or missing.");
            }

            var tempFile = Path.GetTempFileName();
            using (var stream = new FileStream(tempFile, FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            await _s3Service.UploadFileAsync(tempFile, request.File.FileName);

            return Ok(new { Message = "Uploaded successfully!", FileName = request.File.FileName });
        }
    }
   }