namespace RentH2.Services.NotificationAPI.Models.Dto
{
    public class UserNotificationDto
	{
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime? MessageSent { get; set; }
        public string Status { get; set; }
    }
}
