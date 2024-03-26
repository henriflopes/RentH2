using RentH2.Services.EmailAPI.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RentH2.Services.NotificationAPI.Models.Dto;
using System.Text;
using RentH2.Services.NotificationAPI.Services.IServices;

namespace RentH2.Services.NotificationAPI.Messaging
{
    public class RabbitMQOrderConsumer : BackgroundService
	{

        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;
        private readonly string? orderCreatedQueue;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQOrderConsumer(IConfiguration configuration, INotificationService notificationService)
        {
            _configuration = configuration;
            _notificationService = notificationService;

            orderCreatedQueue = _configuration.GetValue<string>("TopicAndQueueNames:OrderCreatedTopic");

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(orderCreatedQueue, false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                OrderDto orderDto = JsonConvert.DeserializeObject<OrderDto>(content);
                HandleMessage(orderDto).GetAwaiter().GetResult();
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(orderCreatedQueue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(OrderDto orderDto)
        {
            _notificationService.LogNotificationPlaced(orderDto).GetAwaiter().GetResult();
        }
    }
}
