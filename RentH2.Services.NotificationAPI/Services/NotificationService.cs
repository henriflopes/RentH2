using RentH2.Services.NotificationAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RentH2.Services.NotificationAPI.Models.Dto;
using RentH2.Services.NotificationAPI.Services.IServices;
using RentH2.Services.NotificationAPI.Utility;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace RentH2.Services.EmailAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMongoCollection<Notification> _notificationCollection;

        //public NotificationService(IOptions<DatabaseSettings> databaseSettings)
        public NotificationService(DbContextOptions<DatabaseSettings> databaseSettings)
        {
            //var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            //var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            //_notificationCollection = mongoDb.GetCollection<Notification>(databaseSettings.Value.CollectionName);
        }

        public async Task LogNotificationPlaced(OrderDto orderDto)
		{

            StringBuilder message = new StringBuilder();

            message.AppendLine("<br/>Caro fulano de tal...");
            message.AppendLine("<br/>");
            message.AppendLine("<br/>Temos uma encomenda para ser entregue por você");
            message.AppendLine("<br/>Pedido: " + orderDto.Description);
            message.AppendLine("<br/>Taxa de Entrega: " + orderDto.ShippingTax);
            message.AppendLine("<br/>");
            message.AppendLine("<br/>Para aceita clique aqui CHAMAR_URL_DE_ACEITE com ID do pedido" + orderDto.Id);

            //string message = "New Notification Placed. <br/> Notification ID : " + notificationDto.Id;
			await LogAndNotify(message.ToString(), "issuer@renth2.com");
		}

		private async Task<bool> LogAndNotify(string message, string email)
		{
			try
			{
                var notification = new Notification();

                UserNotification userNotification = new()
				{
					Sender = email,
					MessageSent = DateTime.Now,
					Message = message
				};

                await _notificationCollection.InsertOneAsync(notification);

				return true;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
