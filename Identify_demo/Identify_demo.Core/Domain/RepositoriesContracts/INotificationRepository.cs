using Identify_demo.Core.DTO;

namespace Identify_demo.Core.Domain.RepositoriesContracts
{
	public interface INotificationRepository
	{
		public Task AddNotification(Notification notification);
		public Task<List<Notification>> GetUserNotifications(string username);
		public Notification ToNotification(AddNotificationRequest request);
	}
}
