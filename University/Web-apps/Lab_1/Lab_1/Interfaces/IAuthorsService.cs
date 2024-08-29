using Lab_1.DTOs;
using Lab_1.Models;

namespace Lab_1.Interfaces
{
	public interface IAuthorsService
	{
		public List<Author> GetAllAuthors();
		public Author? GetAuthorById(int id);
		public bool DeleteAuthorById(int id);
		public bool AddAuthor(Author author);
		public bool UpdateAuthor(UpdateAuthorDTO author, int authorId);
	}
}
