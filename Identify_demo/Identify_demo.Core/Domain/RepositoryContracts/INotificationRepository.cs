namespace Identify_demo.Core.Domain.RepositoryContracts
{
	public interface INotificationRepository
	{
		public Task<List<Notification>> GetUserNotifications(string username);
		public Task AddNotification(Notification notification);
	}
}
