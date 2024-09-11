namespace MainApp
{
	public static class Program
	{
		public static async Task Main()
		{
			var task1 = DisplayZeroAsync();
			var task2 = DisplayOneAsync();

			Console.WriteLine($"Main - {Thread.CurrentThread.ManagedThreadId}");
			await Task.WhenAll(task1, task2);
			Console.WriteLine($"Main - {Thread.CurrentThread.ManagedThreadId}");
		}

		public static Task DisplayZeroAsync()
		{
			return Task.Run(() =>
			{
				for (int i = 0; i < 1000; i++)
				{
					Console.WriteLine($"Task 1 - {Thread.CurrentThread.ManagedThreadId}");
				}
			});
		}

		public static Task DisplayOneAsync()
		{
			return Task.Run(() =>
			{
				for (int i = 0; i < 1000; i++)
				{
					Console.WriteLine($"Task 2 - {Thread.CurrentThread.ManagedThreadId}");
				}
			});
		}
	}
}