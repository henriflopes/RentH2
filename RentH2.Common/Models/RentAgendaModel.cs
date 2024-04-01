namespace RentH2.Common.Models
{
    public class RentAgendaModel
    {
        public string? MotorcycleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TotalDaysInRow { get; set; }
        public string? MotorcycleStatus { get; set; }
        public PlanModel? Plan { get; set; }
    }
}