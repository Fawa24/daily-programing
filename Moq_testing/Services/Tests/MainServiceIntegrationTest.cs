using AutoFixture;
using Moq;
using Services;
using Services.Models;

namespace Tests
{
	public class MainServiceIntegrationTest
	{
		private readonly MainService _service;

		public MainServiceIntegrationTest(MainService service)
		{
			_service = service;
		}

		[Fact]
		public void GetModel_ReturnsValidValue()
		{
			new Mock<IDependency>().Setup(x => x.GetModel()).Returns(new Fixture().Create<ModelToReturn>());

			var actual = _service.GetModel();

			Assert.NotNull(actual);
		}

		private ModelToReturn GetMockedModel()
		{
			return new ModelToReturn()
			{
				Id = 1,
				Name = "test",
				Description = "test description",
			};
		}
	}
}