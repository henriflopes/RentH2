using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RentH2.Domain.Base
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; }
    }
}
