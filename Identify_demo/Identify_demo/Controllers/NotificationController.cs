using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Identify_demo.Web.Controllers
{
	[ApiController]
	[Authorize]
	public class NotificationController : ControllerBase
	{
		private readonly ConnectionFactory _connectionFactory;

		public NotificationController()
		{
			_connectionFactory = new ConnectionFactory()
			{
				HostName = "localhost"
			};
		}

		[HttpPost("send")]
		public ActionResult SendNotification(NotificationRequestDTO notificationRequest)
		{
			string? sender = User?.Identity?.Name;

			if (sender == null) return BadRequest("Cannot set the sender for the notification");

			NotificationRequest notification = notificationRequest.ToNotification(sender);

			using (var connection = _connectionFactory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(
					queue: "q.emergency-notificator",
					durable: true,
					exclusive: false,
					autoDelete: true,
					arguments: null);

				var message = JsonSerializer.Serialize(notification);
				var body = Encoding.UTF8.GetBytes(message);

				channel.BasicPublish(
					exchange: "",
					routingKey: "q.emergency-notificator",
					body: body);

				return Ok("Notification has been published");
			}

			/*[HttpGet("notifications")]
			public async Task<ActionResult<List<>>> GetNotifications()
			{
				List
			}*/
		}
	}
}
