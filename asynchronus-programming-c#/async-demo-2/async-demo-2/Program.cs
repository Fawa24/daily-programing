namespace DemoApp
{
	public static class Program
	{
		public static void Main()
		{
			MakeTea();
		}

		public static string MakeTea()
		{
			var water = BoilWater();
			Console.WriteLine("take the cups out");
			Console.WriteLine("put tea in cups");
			var tea = $"pour {water} in cups";
			Console.WriteLine(tea);
			return tea;
		}

		public static string BoilWater()
		{
			Console.WriteLine("Start the kettle");
			Task.Delay(2000).GetAwaiter().GetResult();

			Console.WriteLine("kettle finished boiling");

			return "water";
		}
	}
}