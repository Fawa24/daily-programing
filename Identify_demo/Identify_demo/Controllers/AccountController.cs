using Identify_demo.Core.Domain.Entities;
using Identify_demo.Core.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identify_demo.Web.Controllers
{
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost("register")]
		public async Task<ActionResult> Register(RegisterDTO registerDTO)
		{
			// TO DO: Check for validation errors
			if (!ModelState.IsValid)
			{
				List<string> validationErrors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
				return BadRequest(validationErrors);
			}

			// TO DO: If there are no errors, store new user into db
			ApplicationUser user = new ApplicationUser()
			{
				UserName = registerDTO.UserName,
				Email = registerDTO.Email,
				PhoneNumber = registerDTO.PhoneNumber,
			};

			IdentityResult result = await _userManager.CreateAsync(user, password: registerDTO.Password);

			if (result.Succeeded)
			{
				return Ok("Registration is succesfull");
			}

			foreach (IdentityError error in result.Errors)
			{
				ModelState.AddModelError("Register", error.Description);
			}

			List<string> errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
			return BadRequest(errors);
		}
	}
}
