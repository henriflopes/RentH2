using RentH2.Infra.Repositories.Base.MongoDB.Interfaces;

namespace RentH2.Infra.Repositories.Base.MongoDB
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
