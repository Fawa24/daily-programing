using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ActionFilters
{
	public class PersonsListActionFilter : IActionFilter
	{
		private readonly ILogger<PersonsListActionFilter> logger;

		public PersonsListActionFilter(ILogger<PersonsListActionFilter> logger)
		{
			this.logger = logger;
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			logger.LogInformation("PersonsListActionFilter.OnActionExecuted");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			logger.LogInformation("PersonsListActionFilter.OnActionExecuting");
		}
	}
}
