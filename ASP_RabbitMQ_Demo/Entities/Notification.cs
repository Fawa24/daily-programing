namespace Entities
{
	public class Notification
	{
		public string? Sender { get; set; }
		public string? Message { get; set; }
		public string? Receiver { get; set; }

		public static List<Notification> GetNotifications()
		{
			var list = new List<Notification>()
			{
				new Notification { Sender = "Sender1", Message = "Alarm!", Receiver = "Receiver2" },
				new Notification { Sender = "Sender1", Message = "Alarm!", Receiver = "Receiver3" },
				new Notification { Sender = "Sender1", Message = "Alarm!", Receiver = "Receiver4" },
				new Notification { Sender = "Sender1", Message = "Alarm!", Receiver = "Receiver5" },
				new Notification { Sender = "Sender2", Message = "Alarm!", Receiver = "Receiver6" },
				new Notification { Sender = "Sender2", Message = "Alarm!", Receiver = "Receiver7" },
				new Notification { Sender = "Sender2", Message = "Alarm!", Receiver = "Receiver8" },
				new Notification { Sender = "Sender2", Message = "Alarm!", Receiver = "Receiver9" }
			};

			return list;
		}
	}
}
