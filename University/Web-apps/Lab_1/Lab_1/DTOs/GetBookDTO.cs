using Lab_1.Models;

namespace Lab_1.DTOs
{
	public class GetBookDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public Author? Author { get; set; }
	}

	public static class BookExtension
	{
		public static GetBookDTO ToGetBookDTO(this Book book)
		{
			return new GetBookDTO
			{
				Id = book.Id,
				Name = book.Name,
				Author = book.Author,
			};
		}
	}
}
