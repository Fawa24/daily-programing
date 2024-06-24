namespace DesignPatterns
{
	public class Journal
	{
		private readonly List<string> entries = new List<string>();

		private static int count = 0;

		public int AddEntry(string entry)
		{
			entries.Add($"{++count}: {entry}");
			return count; // memento???
		}

		public void RemoveEntry(int index)
		{
			entries.RemoveAt(index);
		}

		public override string ToString()
		{
			return string.Join(Environment.NewLine, entries);
		}
	}

	public static class Program
	{
		public static void Main(string[] args)
		{
			var journal = new Journal();

			journal.AddEntry("I cried today");
			journal.AddEntry("I ate a bug");

			Console.WriteLine(journal.ToString());
		}
	}
}