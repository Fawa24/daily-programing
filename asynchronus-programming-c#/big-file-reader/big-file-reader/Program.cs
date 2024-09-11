using System.Diagnostics;

namespace BigFileReader
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			var timeWithoutAsync = await MeasureSpentTimeAsync(Act);
			var timeWithAsync = await MeasureSpentTimeAsync(ActAsync);
			var timeWithAsyncWithWhenAll = await MeasureSpentTimeAsync(ActAsyncWithWhenAll);

			Console.WriteLine('\n');

			Console.WriteLine($"Sync:\t {timeWithoutAsync}\t ms");
			Console.WriteLine($"Async:\t {timeWithAsync}\t ms");
			Console.WriteLine($"WhehAll: {timeWithAsyncWithWhenAll}\t ms");
		}

		private static async Task<int> CountFileWordsAsync(string pathToFile)
		{
			var fileReader = new StreamReader(pathToFile);

			char[] delimiters = { ' ', '\r', '\n', '.', ',', ';', ':', '!', '?' };
			var words = (await fileReader.ReadToEndAsync()).Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

			int counter = words.Length;
			Console.WriteLine($"Completed on thread: {Thread.CurrentThread.ManagedThreadId}");

			return counter;
		}

		private static int CountFileWords(string pathToFile)
		{
			var fileReader = new StreamReader(pathToFile);

			char[] delimiters = { ' ', '\r', '\n', '.', ',', ';', ':', '!', '?' };
			var words = fileReader.ReadToEnd().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

			int counter = words.Length;
			Console.WriteLine($"Completed on thread: {Thread.CurrentThread.ManagedThreadId}");

			return counter;
		}

		private static Task Act()
		{
			return Task.Run(() =>
			{
				Console.WriteLine("Simple method got called");

				for (int i = 0; i < 20; i++)
				{
					CountFileWords("books\\third-book.txt");
				}
			});
		}

		private static async Task ActAsync()
		{
			Console.WriteLine("\nAsync method got called");

			for (int i = 0; i < 20; i++)
			{
				await CountFileWordsAsync("books\\third-book.txt");
			}
		}

		private static Task ActAsyncWithWhenAll()
		{
			Console.WriteLine("\nAsync method with WhenAll got called");

			var tasks = new Task[20];

			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i] = CountFileWordsAsync("books\\third-book.txt");
			}

			return Task.WhenAll(tasks);
		}

		private async static Task<long> MeasureSpentTimeAsync(Func<Task> func)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			await func();

			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
	}
}