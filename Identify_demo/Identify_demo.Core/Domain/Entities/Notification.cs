using System.ComponentModel.DataAnnotations;

namespace Identify_demo.Core.Domain.Entities
{
	public class Notification
	{
		[Key]
		public Guid NotificationId { get; set; }

		[Required]
		public Guid SenderId { get; set; }

		[Required]
		public Guid RecipientId { get; set; }

		[Required]
		public string Message { get; set; } = null!;

		public virtual ApplicationUser Sender { get; set; } = null!;
		public virtual ApplicationUser Recipient { get; set; } = null!;

		public string? GetSenderName() => Sender.UserName;
		public string? GetRecipientName() => Recipient.UserName;
	}

}
