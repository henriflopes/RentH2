using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RentH2.Domain.Base
{
    public interface IDocument
    {

        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
