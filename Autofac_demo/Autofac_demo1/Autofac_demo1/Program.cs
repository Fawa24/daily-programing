using Autofac;
using Autofac_demo1.Interfaces;
using Autofac_demo1.Services;

namespace App
{
	public static class Program
	{
		private static IContainer _container;

		public static void Main(string[] args)
		{
			var builder = new ContainerBuilder();
			builder.RegisterType<DependencyService>().As<IDependencyService>();
			builder.RegisterType<MainService>().As<IMainService>();
			_container = builder.Build();


		}
	}
}