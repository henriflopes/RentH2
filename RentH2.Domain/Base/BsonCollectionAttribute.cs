namespace RentH2.Domain.Base
{
    public class BsonCollectionAttribute : Attribute
    {
        private readonly string _collectionName;

        public BsonCollectionAttribute(string collectionName)
        {
            _collectionName = collectionName;
        }

        public string CollectionName => _collectionName;
    }
}