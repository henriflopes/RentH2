using RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infrastructure.Repositories.Base.MongoDB
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
