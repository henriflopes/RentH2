using MongoDB.Bson;

namespace RentH2.Domain.Base
{
    public abstract class Document : IDocument
    {

  
        public ObjectId Id { get; set; }

        
        public DateTime CreatedAt => Id.CreationTime;
    }
}
