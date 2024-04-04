using RentH2.Domain.Base;

namespace RentH2.Domain.Entities
{
    [BsonCollection("Plans")]
    public class Plan : Document
    {
        public string? Description { get; set; }
        public int TotalDays { get; set; }
        public double DailyPrice { get; set; }
        public double TotalPrice { get; set; }
        public double FineAntecipated { get; set; }
        public double FineDelayed { get; set; }
        public string? Status { get; set; }
    }
}


