namespace RentH2.Services.NotificationAPI.Models.Dto
{
	public class RidersRentsDto
	{
        public string? Id { get; set; }
        public string RentId { get; set; }
		public string PlanId { get; set; }
		public string UserId { get; set; }
		public string MotorcycleId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}


