using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.LogicServices.Abstract;
using Webbing.Assignment.Service.Models;

namespace Webbing.Assignment.Controllers;

[ApiController]
[Route("api")]
public class UsageController : ControllerBase
{
    private readonly ILogger<UsageController> logger;
    private readonly IUsageLogicService usageLogicService;

    public UsageController(ILogger<UsageController> logger, IUsageLogicService usageLogicService)
    {
        this.logger = logger;
		this.usageLogicService = usageLogicService;
    }

    [HttpGet("usages-group-by-sim")]
    [ProducesResponseType(typeof(IEnumerable<SimUsageModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<SimUsageModel>> GetUsagesGroupBySim(
        Guid customerId,
        DateTime FromDate,
        DateTime? ToDate = null)
    {
		return await usageLogicService.GetUsageBySim(customerId, FromDate, ToDate);

	}

    [HttpGet("usages-group-by-customer")]
    [ProducesResponseType(typeof(IEnumerable<CustomerUsageModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<CustomerUsageModel>> GetUsagesGroupByCustomer(
        DateTime FromDate,
        DateTime? ToDate = null)
    {
        return await usageLogicService.GetUsageByCustomer(FromDate, ToDate);
    }
}
