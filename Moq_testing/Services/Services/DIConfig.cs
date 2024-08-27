using Autofac;

namespace Services
{
	public sealed class MyModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<IDependency>().As<Dependency>();
			builder.RegisterType<MainService>().As<MainService>();
		}
	}
}
