using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Entities;
using Webbing.Assignment.Service.Models;

namespace Webbing.Assignment.Service.Repository.Abstract
{
    public interface IUsageRepository : IBaseRepository
	{
        Task Create(IEnumerable<Usage> usages);
		Task<IEnumerable<SimUsageModel>> ReadUsageBySim(Guid customerId, DateTime fromDate, DateTime toDate);
		Task<IEnumerable<CustomerUsageModel>> ReadUsageByCustomer(DateTime fromDate, DateTime toDate);
	}
}