using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentH2.Common.Models
{
    public class RegistrationRequestModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string DocumentId { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverLicenseId { get; set; }
        public string DriverLicenseClass { get; set; }
        public string? DriverLicenseImgUrl { get; set; }
        public string? DriverLicenseImgPath { get; set; }
        public string? Role { get; set; }
        public IFormFile? Image { get; set; }
    }
}
