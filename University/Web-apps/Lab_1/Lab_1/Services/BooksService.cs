using Lab_1.Interfaces;
using Lab_1.Models;

namespace Lab_1.Services
{
	public class BooksService : IBooksService
	{
		private List<Book> _books;

		public BooksService()
		{
			_books =
			[
				new Book
				{
					Id = 1,
					Name = "And the one in the field warrior",
					Author = new Author
					{
						Id = 1,
						Name = "Yuriy Dold-Mychailyck"
					}
				},
				new Book
				{
					Id = 2,
					Name = "Pro C# 10 with .NET 6",
					Author = new Author
					{
						Id = 2,
						Name = "Andrew Troelsen"
					}
				},
			];
		}

		public bool AddBook(Book book)
		{
			_books.Add(book);
			return true;
		}

		public bool DeleteBookById(int id)
		{
			var book = GetBookById(id);

			if (book != null)
			{
				return _books.Remove(book);
			}
			return false;
		}

		public List<Book> GetAllBooks()
		{
			return _books;
		}

		public Book? GetBookById(int id)
		{
			return _books.FirstOrDefault(a => a.Id == id);
		}
	}
}
