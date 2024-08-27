using Services.Models;

namespace Services
{
	public interface IDependency
	{
		public ModelToReturn? GetModel();
	}

	public class Dependency : IDependency
	{
		public ModelToReturn? GetModel()
		{
			return null;
		}
	}
}
