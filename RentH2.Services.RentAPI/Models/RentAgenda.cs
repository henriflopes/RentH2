namespace RentH2.Services.RentAPI.Models.Dto
{
	public class RentAgenda
	{
		public string? MotorcycleId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public double TotalDaysInRow { get; set; }
		public string? MotorcycleStatus { get; set; }
		public Plan Plan { get; set; }
	}
}