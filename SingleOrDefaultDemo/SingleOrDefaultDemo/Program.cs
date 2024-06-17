public class Program
{
	public static void Main()
	{
		List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

		try
		{
			int singleElement = numbers.SingleOrDefault(t => t == 6);
			Console.WriteLine("Single Element: " + singleElement);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}

		List<int> multipleNumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
		try
		{
			int singleElement = multipleNumbers.Single();
			Console.WriteLine("Single Element: " + singleElement);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
	}
}
