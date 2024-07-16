using Webbing.Assignment.Service.LogicService;

namespace Webbing.Assignment.Api.Controllers
{

	[ApiController]
	[Route("api/functions")]
	public class FunctionsController : Controller
	{
		// Simulates serverless API like Azure Functions/Lambda running every day (or even hour?)
		[HttpPost(nameof(SaveUsageOfNetworkEvents))]
		public async Task SaveUsageOfNetworkEvents([FromBody] DateTime date, [FromServices] UsageLogicService usageLogicService)
		{
			await usageLogicService.StoreUsageForDate(date);
		}
	}
}
