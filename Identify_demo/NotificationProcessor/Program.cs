using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationProcessor;

public static class Program
{
	public static void Main()
	{
		CreateHostBuider().Build().Run();
	}

	private static IHostBuilder CreateHostBuider() =>
		Host.CreateDefaultBuilder()
		.ConfigureServices((hostContext, services) =>
		{
			services.AddHostedService<NotificationProcessorService>();
		});
}