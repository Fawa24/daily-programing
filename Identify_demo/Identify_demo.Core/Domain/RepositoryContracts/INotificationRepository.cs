using Identify_demo.Core.DTO;

namespace Identify_demo.Core.Domain.RepositoryContracts
{
	public interface INotificationRepository
	{
		public Task<List<NotificationResponce>> GetUserNotifications(string username);
	}
}
