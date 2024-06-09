using Identify_demo.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Identify_demo.Infrastructure.DbContexts
{
	public class UsersDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public DbSet<Notification> Notifications { get; set; }

		public UsersDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Notification>(entity =>
			{
				entity.HasOne(n => n.Sender)
					.WithMany()
					.HasForeignKey(n => n.SenderId)
					.OnDelete(DeleteBehavior.Restrict)
					.IsRequired();

				entity.HasOne(n => n.Recipient)
					.WithMany()
					.HasForeignKey(n => n.RecipientId)
					.OnDelete(DeleteBehavior.Restrict)
					.IsRequired();
			});
		}
	}
}
