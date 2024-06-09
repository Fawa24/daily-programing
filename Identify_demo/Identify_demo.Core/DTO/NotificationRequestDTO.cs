using System.ComponentModel.DataAnnotations;

public class NotificationRequestDTO
{
	public List<string> Recipients { get; set; } = null!;

	[Required(ErrorMessage = "Message text can not be null")]
	public string Message { get; set; } = null!;
}
