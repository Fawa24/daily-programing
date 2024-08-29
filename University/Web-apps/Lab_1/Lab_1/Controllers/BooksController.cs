using Lab_1.DTOs;
using Lab_1.Interfaces;
using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
	public class BooksController : ControllerBase
	{
		private readonly IBooksService _booksService;

		public BooksController(IBooksService booksService)
		{
			_booksService = booksService;
		}

		[HttpGet("books/")]
		public ActionResult<List<Book>> GetAllBooks()
		{
			return Ok(_booksService.GetAllBooks());
		}

		[HttpGet("books/{id}")]
		public ActionResult<Book> GetBookById(int id)
		{
			var book = _booksService.GetBookById(id);

			if (book == null)
			{
				return BadRequest($"Invalid input: no book has {id} id");
			}

			return Ok(book);
		}

		[HttpPost("books/")]
		public ActionResult AddBook([FromBody] Book book)
		{
			if (_booksService.AddBook(book))
			{
				return Ok("Added successfully");
			}

			return BadRequest("Something went wrong");
		}

		[HttpDelete("books/{id}")]
		public ActionResult DeleteBookById(int id)
		{
			if (_booksService.DeleteBookById(id))
			{
				return Ok("Deleted successfully");
			}

			return BadRequest($"Invalid input: no book has {id} id");
		}

		[HttpPost("books/{id}")]
		public ActionResult UpdateBook([FromBody] UpdateBookDTO book, int id)
		{
			if (_booksService.UpdateBook(book, id))
			{
				return Ok("Updated successfuly");
			}
			return BadRequest("Something went wrong");
		}
	}
}
