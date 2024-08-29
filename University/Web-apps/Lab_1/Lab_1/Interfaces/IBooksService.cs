using Lab_1.DTOs;
using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IBooksService
	{
		public List<Book> GetAllBooks();
		public Book? GetBookById(int id);
		public bool DeleteBookById(int id);
		public bool AddBook(Book book);
		public bool UpdateBook(UpdateBookDTO book, int bookId);
	}
}