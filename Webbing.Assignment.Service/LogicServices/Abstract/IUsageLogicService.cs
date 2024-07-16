using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Models;

namespace Webbing.Assignment.Service.LogicServices.Abstract
{
    public interface IUsageLogicService
    {
        Task<IEnumerable<CustomerUsageModel>> GetUsageByCustomer(DateTime from, DateTime? to = null);
        Task<IEnumerable<SimUsageModel>> GetUsageBySim(Guid customerId, DateTime from, DateTime? to = null);
        Task StoreUsageForDate(DateTime dateTime);
    }
}