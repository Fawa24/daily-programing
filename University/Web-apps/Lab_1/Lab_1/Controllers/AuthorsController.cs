using Lab_1.Interfaces;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
	public class AuthorsController : ControllerBase
	{
		private readonly IAuthorsService _authorsService;

		public AuthorsController(IAuthorsService authorsService)
		{
			_authorsService = authorsService;
		}

		[HttpGet("authors/")]
		public ActionResult<List<Author>> GetAllAuthors()
		{
			return Ok(_authorsService.GetAllAuthors());
		}

		[HttpGet("authors/{id}")]
		public ActionResult<Author> GetAuthorById(int id)
		{
			var author = _authorsService.GetAuthorById(id);

			if (author == null)
			{
				return BadRequest($"Invalid input: no author has {id} id");
			}

			return Ok(author);
		}

		[HttpPost("authors/")]
		public ActionResult AddAuthor([FromBody] Author author)
		{
			if (_authorsService.AddAuthor(author))
			{
				return Ok("Added successfully");
			}

			return BadRequest("Something went wrong");
		}

		[HttpDelete("authors/{id}")]
		public ActionResult DeleteAuthor(int id)
		{
			if (_authorsService.DeleteAuthorById(id))
			{
				return Ok("Deleted successfully");
			}

			return BadRequest($"Invalid input: no author has {id} id");
		}
	}
}
