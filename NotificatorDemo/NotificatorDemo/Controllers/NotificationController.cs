using Entities;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NotificatorDemo.Controllers
{
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly ConnectionFactory _connectionFactory;

		public NotificationController()
		{
			_connectionFactory = new ConnectionFactory()
			{
				HostName = "localhost",
				Port = 5672,
				UserName = "guest",
				Password = "guest"
			};
		}

		public async Task<ActionResult<string>> Index()
		{
			NotificationRequest request = NotificationRequest.GetNotification();

			using (var connection = _connectionFactory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(
					queue: "q.notificator.demo",
					durable: true,
					exclusive: false,
					autoDelete: false,
					arguments: null);

				var serializedMessage = JsonSerializer.Serialize(request);
				var body = Encoding.UTF8.GetBytes(serializedMessage);

				channel.BasicPublish(
					exchange: "",
					routingKey: "q.notificator.demo",
					body: body);
			}

			return Ok("Notification request sent");
		}
	}
}
