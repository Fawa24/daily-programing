namespace DesignPatterns
{
	public class Document
	{

	}

	public interface IMAchine
	{
		void Print(Document document);
		void Scan(Document document);
		void Fax(Document document);
	}

	public class MultiFunctionPrinter : IMAchine
	{
		public void Fax(Document document)
		{
			// implementation
		}

		public void Print(Document document)
		{
			// implementation
		}

		public void Scan(Document document)
		{
			// implementation
		}
	}

	public class OldFashionedPrinter : IMAchine
	{
		public void Fax(Document document)
		{
			// implementation
		}

		public void Print(Document document)
		{
			throw new NotImplementedException(); // no implementation
		}

		public void Scan(Document document)
		{
			throw new NotImplementedException(); // no implementation
		}
	}

	public static class Program
	{
		public static void Main(string[] args)
		{

		}
	}
}