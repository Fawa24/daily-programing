namespace DesignPatterns
{
	public class Document
	{

	}

	public interface IPrinter
	{
		void Print(Document document);
	}

	public interface IScaner
	{
		void Scan(Document document);
	}

	public interface IFaxer
	{
		void Fax(Document document);
	}

	public class MultiFunctionPrinter : IPrinter, IFaxer, IScaner
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

	public class OldFashionedPrinter : IFaxer
	{
		public void Fax(Document document)
		{
			// implementation
		}
	}

	public static class Program
	{
		public static void Main(string[] args)
		{

		}
	}
}