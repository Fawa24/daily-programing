using Autofac_demo1.Interfaces;
using Autofac_demo1.Models;

namespace Autofac_demo1.Services
{
	public class MainService : IMainService
	{
		private readonly IDependencyService _dependencyService;

		public MainService(IDependencyService dependencyService)
		{
			_dependencyService = dependencyService;
		}

		public DemoModel? GetDemoModel()
		{
			return _dependencyService.GetModel();
		}
	}
}
