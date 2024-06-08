using Identify_demo.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Identify_demo.Infrastructure.DbContexts
{
	public class UsersDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
	{
		public UsersDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}
