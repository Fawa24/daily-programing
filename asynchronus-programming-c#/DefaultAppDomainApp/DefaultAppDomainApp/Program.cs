namespace DefaultAppDomainApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DisplayAppDomainStats();
		}

		static void DisplayAppDomainStats()
		{
			var appDomain = AppDomain.CurrentDomain;

			Console.WriteLine($"FriendlyName: {appDomain.FriendlyName}");
			Console.WriteLine($"Id: {appDomain.Id}");
			Console.WriteLine($"IsDefaultAppDomain: {appDomain.IsDefaultAppDomain()}");
			Console.WriteLine($"BaseDirectory: {appDomain.BaseDirectory}");
			Console.WriteLine($"ApplicationBase: {appDomain.SetupInformation.ApplicationBase}");
			Console.WriteLine($"TargetFrameworkName: {appDomain.SetupInformation.TargetFrameworkName}");

			Console.WriteLine("\n**************************************************\n");
		}
	}
}
