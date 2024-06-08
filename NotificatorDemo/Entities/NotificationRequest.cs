namespace Entities
{
	public class NotificationRequest
	{
		public List<string> Recipients { get; set; } = null!;
		public string Message { get; set; } = null!;

		public static NotificationRequest GetNotification()
		{
			return new NotificationRequest()
			{
				Recipients = new List<string>
				{
						"Sergiy", "Katya"
				},
				Message = "Hello there!",
			};
		}
		
	}

}
