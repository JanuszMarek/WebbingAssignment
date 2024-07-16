using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Enums;
using Webbing.Assignment.Service.Models;

namespace Webbing.Assignment.Service.Repository.Abstract
{
	public interface INetworkEventRepository : IBaseRepository
	{
		Task<IEnumerable<GroupedNetworkEventDTO>> ReadGroupedNetworkEventsByDate(DateTime dateTime);
		Task SetNetworkEventStatus(IEnumerable<Guid> ids, NetworkEventStatus status);
		Task<IEnumerable<SimUsageModel>> ReadUsageBySim(Guid customerId, DateTime dateTime);
		Task<IEnumerable<CustomerUsageModel>> ReadUsageByCustomer(DateTime dateTime);
	}
}