using Autofac;
using Services.Models;

namespace Services
{
	public class MainService
	{
		private readonly ILifetimeScope _scope;

		public MainService(ILifetimeScope scope)
		{
			_scope = scope;
		}

		public ModelToReturn? GetModel()
		{
			ModelToReturn? result = null;
			using (var scope = _scope)
			{
				result = scope.Resolve<IDependency>().GetModel();
			}
			return result;
		}
	}
}
