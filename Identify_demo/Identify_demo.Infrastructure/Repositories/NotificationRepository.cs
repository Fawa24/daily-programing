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

		public async Task AddNotification(Notification notification)
		{
			await _db.Notifications.AddAsync(notification);
			await _db.SaveChangesAsync();
		}

		public async Task<List<Notification>> GetUserNotifications(string username)
		{
			return await _db.Notifications
				.Include(nameof(Notification.Sender))
				.Include(nameof(Notification.Recipient))
				.ToListAsync();
		}

		public Notification ToNotification(AddNotificationRequest request)
		{
			return new Notification()
			{
				NotificationId = Guid.NewGuid(),
				Message = request.Message,
				SenderId = _db.Users.FirstOrDefault(user => user.UserName == request.SenderName).Id,
				RecipientId = _db.Users.FirstOrDefault(user => user.UserName == request.RecipientName).Id,
			};
		}
	}
}
