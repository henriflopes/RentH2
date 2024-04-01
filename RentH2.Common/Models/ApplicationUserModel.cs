using Newtonsoft.Json;
using RentH2.Common.Models.Base;

namespace RentH2.Common.Models
{
    public class ApplicationUserModel : HttpBaseResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("surName")]
        public string? SurName { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("documentId")]
        public string DocumentId { get; set; }
        [JsonProperty("dateBirth")]
        public DateTime DateBirth { get; set; }
        [JsonProperty("driverLicenseId")]
        public string? DriverLicenseId { get; set; }
        [JsonProperty("driverLicenseClass")]
        public string? DriverLicenseClass { get; set; }
        [JsonProperty("driverLicenseImageUrl")]
        public string? DriverLicenseImageUrl { get; set; }
        [JsonProperty("driverLicenseImageLocalPath")]
        public string? DriverLicenseImageLocalPath { get; set; }
    }
}
