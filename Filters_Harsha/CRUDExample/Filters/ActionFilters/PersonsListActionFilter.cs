using Microsoft.AspNetCore.Mvc.Filters;
using ServiceContracts.DTO;

namespace CRUDExample.Filters.ActionFilters
{
	public class PersonsListActionFilter : IActionFilter
	{
		private readonly ILogger<PersonsListActionFilter> _logger;

		public PersonsListActionFilter(ILogger<PersonsListActionFilter> logger)
		{
			this._logger = logger;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			_logger.LogInformation("PersonsListActionFilter.OnActionExecuted");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			_logger.LogInformation("PersonsListActionFilter.OnActionExecuting");

			if (context.ActionArguments.ContainsKey("searchBy"))
			{
				string? searchBy = Convert.ToString(context.ActionArguments["searchBy"]);

				if (!string.IsNullOrEmpty(searchBy))
				{
					var searchByOptions = new List<string>()
					{
						nameof(PersonResponse.PersonName),
						nameof(PersonResponse.Email),
						nameof(PersonResponse.DateOfBirth),
						nameof(PersonResponse.Gender),
						nameof(PersonResponse.CountryID),
						nameof(PersonResponse.Address),
					};

					if (searchByOptions.Any(temp => temp == searchBy) == false)
					{
						_logger.LogInformation("searchBy actual value {searchBy}", searchBy);
						context.ActionArguments["searchBy"] = nameof(PersonResponse.PersonName);

						_logger.LogInformation("searchBy updated value {searchBy}", context.ActionArguments["searchBy"]);
					}
				}
			}
		}
	}
}
