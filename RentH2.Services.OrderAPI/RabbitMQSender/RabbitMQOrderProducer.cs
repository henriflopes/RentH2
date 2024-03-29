﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace RentH2.Services.OrderAPI.RabbitMQSender
{
    public class RabbitMQOrderProducer : IRabbitMQOrderProducer
	{
		private readonly string _hostName;
		private readonly string _userName;
		private readonly string _password;
		private IConnection _connection;

		public RabbitMQOrderProducer()
		{
			_hostName = "localhost";
			_userName = "guest";
			_password = "guest";
		}

		public void PostMessage(object message, string queueName)
		{
			if (ConnectionExists())
			{
				using var channel = _connection.CreateModel();
				channel.QueueDeclare(queueName, false, false, false, null);
				var json = JsonConvert.SerializeObject(message);
				var body = Encoding.UTF8.GetBytes(json);
				channel.BasicPublish(exchange: "", routingKey: queueName, null, body: body);
			}

		}

		private void CreateConnection()
		{
			try
			{
				var factory = new ConnectionFactory
				{
					HostName = _hostName,
					UserName = _userName,
					Password = _password
				};

				_connection = factory.CreateConnection();
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		private bool ConnectionExists()
		{
			if (_connection == null)
			{
				CreateConnection();
			}
			return true;
		}
	}
}
