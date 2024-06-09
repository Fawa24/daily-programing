using Identify_demo.Core.Domain.Entities;
using Identify_demo.Core.Domain.RepositoryContracts;
using Identify_demo.Core.DTO;
using Identify_demo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Identify_demo.Infrastructure.Repositories
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly UsersDbContext _db;

		public NotificationRepository(UsersDbContext db)
		{
			_db = db;
		}

		public async Task<List<NotificationResponce>> GetUserNotifications(string username)
		{
			return await _db.Notifications
				.Include(nameof(Notification.Sender))
				.Include(nameof(Notification.Recipient))
				.Select(temp => temp.ToNotificationResponce())
				.ToListAsync();
		}
	}
}
