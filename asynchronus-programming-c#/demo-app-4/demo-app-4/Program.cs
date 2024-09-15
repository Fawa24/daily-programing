using System.Diagnostics;

namespace demo_app_4
{
	public static class Program
	{
		private readonly static string PathToFile = "books\\third-book.txt";

		public static async Task Main(string[] args)
		{
			ActSync();
			await ActAsync();
		}

		public static int CountWords()
		{
			char[] delimiters = new char[] { ' ', '\r', '\n', '.', ',', ';', ':', '!', '?' };
			var fileReader = new StreamReader(PathToFile);
			string text = fileReader.ReadToEnd();
			string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
			int count = words.Length;

			return count;
		}

		public static Task<int> CountWordsTask()
		{
			return Task.Run(() =>
			{
				char[] delimiters = new char[] { ' ', '\r', '\n', '.', ',', ';', ':', '!', '?' };
				var fileReader = new StreamReader(PathToFile);
				string text = fileReader.ReadToEnd();
				string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
				int count = words.Length;

				return count;
			});
		}

		public static void ActSync()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var count = CountWords();
			Task.Delay(5000).Wait();

			Console.WriteLine($"Count: {count}\t Time: {stopwatch.ElapsedMilliseconds.ToString()}");
		}

		public static async Task ActAsync()
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			var task = CountWordsTask();
			Task.Delay(5000).Wait();
			var count = await task;

			Console.WriteLine($"Count: {count}\t Time: {stopwatch.ElapsedMilliseconds.ToString()}");
		}
	}
}
