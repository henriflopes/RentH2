using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RentH2.Domain.Contracts
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        Guid? Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
