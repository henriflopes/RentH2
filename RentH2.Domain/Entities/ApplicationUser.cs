using Microsoft.AspNetCore.Identity;

namespace RentH2.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? SurName { get; set; }
        public string DocumentId { get; set; }
        public DateTime DateBirth { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string? DriverLicenseId { get; set; }
        public string? DriverLicenseClass { get; set; }
        public string? DriverLicenseImageUrl { get; set; }
        public string? DriverLicenseImageLocalPath { get; set; }
    }
}
