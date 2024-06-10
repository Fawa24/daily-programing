using Identify_demo.Core.Domain.RepositoriesContracts;

namespace Identify_demo.Core.Services
{
	public class NotificationRequestService
	{
		private readonly INotificationRepository _repository;

		public NotificationRequestService(INotificationRepository repository)
		{
			_repository = repository;
		}


	}
}
