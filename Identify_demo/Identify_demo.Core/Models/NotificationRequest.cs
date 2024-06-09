using System.ComponentModel.DataAnnotations;

public class NotificationRequest
{
	public string Sender { get; set; } = null!;

	public List<string> Recipients { get; set; } = null!;

	[Required(ErrorMessage = "Message text can not be null")]
	public string Message { get; set; } = null!;
}

public static class NotificationRequestDTOExtension
{
	public static NotificationRequest ToNotification(this NotificationRequestDTO notification, string sender)
	{
		return new NotificationRequest()
		{
			Sender = sender,
			Recipients = notification.Recipients,
			Message = notification.Message
		};
	}
}
