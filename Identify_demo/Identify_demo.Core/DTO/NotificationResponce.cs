using Identify_demo.Core.Domain.Entities;

namespace Identify_demo.Core.DTO
{
	public class NotificationResponce
	{
		public Guid NotificationId { get; set; }
		public string Sender { get; set; } = null!;
		public string Recipient { get; set; } = null!;
		public string Message { get; set; } = null!;
	}

	public static class NotificationExtension
	{
		public static NotificationResponce ToNotificationResponce(this Notification notification)
		{
			return new NotificationResponce
			{
				NotificationId = notification.NotificationId,
				Sender = notification.GetSenderName(),
				Recipient = notification.GetRecipientName(),
				Message = notification.Message
			};
		}
	}
}
