using Lab_1.DTOs;
using Lab_1.Interfaces;
using Lab_1.Models;

namespace Lab_1.Services
{
	public class AuthorService : IAuthorsService
	{
		private List<Author> _authors;

		public AuthorService()
		{
			_authors =
			[
				new Author
				{
					Id = 1,
					Name = "Yuriy Dold-Mychailyck"
				},
				new Author
				{
					Id = 2,
					Name = "Andrew Troelsen"
				}
			];
		}

		public bool AddAuthor(Author author)
		{
			_authors.Add(author);
			return true;
		}

		public bool DeleteAuthorById(int id)
		{
			var author = GetAuthorById(id);

			if (author != null)
			{
				return _authors.Remove(author);
			}
			return false;
		}

		public List<Author> GetAllAuthors()
		{
			return _authors;
		}

		public Author? GetAuthorById(int id)
		{
			return _authors.FirstOrDefault(a => a.Id == id);
		}

		public bool UpdateAuthor(UpdateAuthorDTO author, int authorId)
		{
			var authorToUpdate = _authors.FirstOrDefault(a => a.Id == authorId);

			if (authorToUpdate != null)
			{
				authorToUpdate.Name = author.Name;
				return true;
			}

			return false;
		}
	}
}
