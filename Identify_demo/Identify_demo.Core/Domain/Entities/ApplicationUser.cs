using Microsoft.AspNetCore.Identity;

namespace Identify_demo.Core.Domain.Entities
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		// Id
		// UserName
		// Email
		// PasswordHash
		// PhoneNumber
	}
}
