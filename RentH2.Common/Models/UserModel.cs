namespace RentH2.Common.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateBirth { get; set; }
        public string? DriverLicenseId { get; set; }
        public string? DriverLicenseClass { get; set; }
        public string? DriverLicenseImageUrl { get; set; }
        public string? DriverLicenseImageLocalPath { get; set; }
    }
}
