using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RentH2.Services.NotificationAPI.Models
{
	public class UserNotification
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? MessageSent { get; set; }
        public string Status { get; set; }
    }
}
