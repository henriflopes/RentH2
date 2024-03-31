using Newtonsoft.Json;
using RentH2.Common.Models.Base;

namespace RentH2.Common.Models
{
    public class MotorcycleModel : HttpBaseResult
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("year")]
        public string? Year { get; set; }

        [JsonProperty("numberPlate")]
        public string NumberPlate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
