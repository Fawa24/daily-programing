using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace NotificationProcessor
{
	public class NotificationProcessorService : BackgroundService
	{
		private readonly ConnectionFactory _connectionFactory;

		public NotificationProcessorService()
		{
			_connectionFactory = new ConnectionFactory() { HostName = "localhost" };
		}

		protected override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			using (var connection = _connectionFactory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(
					queue: "q.emergency-notificator",
					durable: true,
					exclusive: false,
					autoDelete: true,
					arguments: null);

				var consumer = new EventingBasicConsumer(channel);

				consumer.Received += Consumer_Received;

				channel.BasicConsume(
					queue: "q.emergency-notificator",
					autoAck: true,
					consumer: consumer);

				await Task.Delay(Timeout.Infinite, cancellationToken);
			}
		}

		private void Consumer_Received(object? sender, BasicDeliverEventArgs e)
		{
			var body = e.Body.ToArray();
			var message = Encoding.UTF8.GetString(body);
			NotificationRequest? notificationRequest = JsonSerializer.Deserialize<NotificationRequest>(message);

			try
			{
				foreach (var recipient in notificationRequest.Recipients)
				{
					Console.WriteLine(recipient);
				}
			}
			catch (NullReferenceException ex)
			{
				Console.WriteLine($"NotificationRequest is null: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Something went wrong: {ex.Message}");
			}
		}
	}
}
