using Identify_demo.Core.DTO;
using Identify_demo.Infrastructure.Repositories;
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
		private readonly NotificationRepository _notificationRepository;

		public NotificationController(ConnectionFactory connectionFactory, NotificationRepository notificationRepository)
		{
			_connectionFactory = connectionFactory;
			_connectionFactory.HostName = "localhost";
			_notificationRepository = notificationRepository;
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
		}

		[HttpGet("notifications")]
		public async Task<ActionResult<List<NotificationResponce>>> GetNotifications()
		{
			string username = User?.Identity?.Name;
			List<NotificationResponce> result = (await _notificationRepository.GetUserNotifications(username))
				.Select(n => n.ToNotificationResponce()).ToList();

			return Ok(result);
		}
	}
}
