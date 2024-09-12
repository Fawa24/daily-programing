namespace DemoApp
{
	public static class Program
	{
		public async static Task Main()
		{
			await MakeTeaAsync();
		}

		public async static Task<string> MakeTeaAsync()
		{
			var boiling = BoilWaterAsync();
			Console.WriteLine("take the cups out");
			Console.WriteLine("put tea in cups");
			var water = await boiling;
			var tea = $"pour {water} in cups";
			Console.WriteLine(tea);
			return tea;
		}

		public async static Task<string> BoilWaterAsync()
		{
			Console.WriteLine("Start the kettle");
			await Task.Delay(2000);

			Console.WriteLine("kettle finished boiling");

			return "water";
		}
	}
}