using System.Diagnostics;

namespace Demo3
{
	public static class Program
	{
		public static async Task Main()
		{
			var stopWatch1 = new Stopwatch();
			stopWatch1.Start();
			await ActAsync();
			var asyncTime = stopWatch1.Elapsed;

			var stopWatch2 = new Stopwatch();
			stopWatch2.Start();
			await ActSync();
			var syncTime = stopWatch2.Elapsed;

			Console.WriteLine($"Async time:\t {asyncTime}\t");
			Console.WriteLine($"Sync time:\t {syncTime}\t");
		}

		public static async Task ActSync()
		{
			// Waiting for task to complete
			await LongTaskAsync();

			// Another long task which starts after the first task got completed
			Task.Delay(3000).Wait();
		}

		public static async Task ActAsync()
		{
			// Starting the task, which going to complete asynchronously
			var task = LongTaskAsync();

			// Another long task which is not waiting for the end of first task
			Task.Delay(3000).Wait();

			// Waiting for the completion of the first task
			await task;
		}

		public static Task LongTaskAsync()
		{
			// Do something for 5 seconds
			return Task.Delay(5000);
		}
	}
}