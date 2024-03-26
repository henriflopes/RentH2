using Microsoft.EntityFrameworkCore;

namespace RentH2.Services.NotificationAPI.Utility
{
	public class DatabaseSettings : DbContext
    {
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public string CollectionName { get; set; }
	}
}
