using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RentH2.Domain.Base
{
    public abstract class Document : IDocument
    {

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt => Id.CreationTime;
    }
}
