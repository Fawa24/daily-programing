using Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationProcessor.Services
{
	public class NotificationProcessorService : BackgroundService
	{
		private readonly ConnectionFactory _connectionFactory;

		public NotificationProcessorService()
		{
			_connectionFactory = new ConnectionFactory()
			{
				HostName = "localhost",
				Port = 5672,
				UserName = "guest",
				Password = "guest"
			};
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			using (var connection = _connectionFactory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(
					queue: "q.notificator.demo",
					durable: true,
					exclusive: false,
					autoDelete: false,
					arguments: null);

				var consumer = new EventingBasicConsumer(channel);
				consumer.Received += (model, ea) =>
				{
					var body = ea.Body.ToArray();
					var message = Encoding.UTF8.GetString(body);
					var notificationRequest = JsonSerializer.Deserialize<NotificationRequest>(message);

					if (notificationRequest != null && notificationRequest.Recipients != null)
					{
						foreach (var recipient in notificationRequest.Recipients)
						{
							Console.WriteLine($"To: {recipient} Message: {notificationRequest.Message}");
						}
					}
				};

				channel.BasicConsume(
					queue: "q.notificator.demo",
					autoAck: false,
					consumer: consumer);


			}

			await Task.Delay(Timeout.Infinite, stoppingToken);
		}
	}
}
