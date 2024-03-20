namespace RentH2.Services.OrderAPI.RabbitMQSender
{
	public interface IRabbitMQOrderProducer
    {
		void PostMessage(Object message, string queueName);
	}
}
