using System.ComponentModel.DataAnnotations;

namespace Identify_demo.Core.DTO
{
	public class LoginDTO
	{
		[Required(ErrorMessage = "User name can not be blank")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password can not be blank")]
		public string Password { get; set; }
	}
}
