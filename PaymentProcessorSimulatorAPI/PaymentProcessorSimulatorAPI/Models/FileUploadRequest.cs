using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PaymentApi.Models
{
    public class FileUploadRequest
    {
        [Required]
        public IFormFile File { get; set; } = null!; // ! to avoid nullability warnings
    }
}