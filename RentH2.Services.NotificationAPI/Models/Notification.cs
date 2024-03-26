using RentH2.Services.NotificationAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace RentH2.Services.NotificationAPI.Models
{
	
	[Collection("Notifications")]
	public class Notification
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

        public Order? order { get; set; }

        public List<UserNotification>? Notifications { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Timestamp { get; set; }

		public string Status { get; set; }
	}
}


