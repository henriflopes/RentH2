namespace RentH2.Infrastructure.Repositories.Base.MongoDB.Interfaces
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
