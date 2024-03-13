namespace RentH2.Services.RentAPI.Models.Dto
{
	public class RentAgendaDto
	{
		public string? MotorcycleId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public double TotalDaysInRow { get; set; }
		public string? MotorcycleStatus { get; set; }
		public PlanDto Plan { get; set; }
	}
}