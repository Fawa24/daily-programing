using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Producer.Controllers
{
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly IHttpClientFactory _httpClientFactory;
		const string url = "";

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpPost]
		public async Task<ActionResult<string>> SendNotifications()
		{
			var list = Notification.GetNotifications();

			// Invoking another API

			HttpClient client = _httpClientFactory.CreateClient();

			StringContent jsonContent = new StringContent(
				content: JsonSerializer.Serialize(list),
				encoding: Encoding.UTF8,
				mediaType: "application/json");

			HttpResponseMessage response = await client.PostAsync(url, jsonContent);

			if (response.IsSuccessStatusCode)
			{
				return Ok(list);
			}
			else
			{
				return StatusCode((int)response.StatusCode, response.ReasonPhrase);
			}
		}
	}
}
