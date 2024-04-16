using Newtonsoft.Json;
using RentH2.Domain.Models.Base;

namespace RentH2.Domain.Models
{
    public class PlanModel : HttpBaseResult
    {
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("totalDays")]
        public int TotalDays { get; set; }
        [JsonProperty("dailyPrice")]
        public double DailyPrice { get; set; }
        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
        [JsonProperty("fineAntecipated")]
        public double FineAntecipated { get; set; }
        [JsonProperty("fineDelayed")]
        public double FineDelayed { get; set; }
        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}


