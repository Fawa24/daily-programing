namespace Identify_demo.Core.DTO
{
	public class AddNotificationRequest
	{
		public string SenderName { get; set; } = null!;

		public string RecipientName { get; set; } = null!;

		public string Message { get; set; } = null!;
	}
}
