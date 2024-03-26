using RentH2.Services.NotificationAPI.Models.Dto;

namespace RentH2.Services.NotificationAPI.Models.Dto
{
    public class NotificationDto
	{
        public string? Id { get; set; }

        public Order? order { get; set; }

        public List<UserNotificationDto>? Notifications { get; set; }

        public DateTime Timestamp { get; set; }

        public string Status { get; set; }
    }
}
