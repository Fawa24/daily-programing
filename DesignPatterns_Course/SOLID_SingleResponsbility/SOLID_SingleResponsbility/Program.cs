using System.Diagnostics;

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

	public class Persistence
	{
		public void SaveToFinal(Journal journal, string filename, bool overwrite = false)
		{
			if (overwrite || !File.Exists(filename))
			{
				File.WriteAllText(filename, journal.ToString());
			}
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

			var persistence = new Persistence();
			var fileName = @"c:\temp\journal.txt";

			persistence.SaveToFinal(journal, fileName, true);

			if (File.Exists(fileName))
			{
				Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
			}
			else
			{
				Console.WriteLine($"File {fileName} does not exist.");
			}
		}
	}
}