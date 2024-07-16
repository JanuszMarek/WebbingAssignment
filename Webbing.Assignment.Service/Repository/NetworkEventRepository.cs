using Microsoft.EntityFrameworkCore;
using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Entities;
using Webbing.Assignment.Service.Enums;
using Webbing.Assignment.Service.Models;
using Webbing.Assignment.Service.Repository.Abstract;

namespace Webbing.Assignment.Service.Repository
{
	public class NetworkEventRepository : BaseRepository<NetworkEvent, ApplicationDbContext>, INetworkEventRepository
	{
		public NetworkEventRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<IEnumerable<GroupedNetworkEventDTO>> ReadGroupedNetworkEventsByDate(DateTime dateTime)
		{
			var data = await dbSet
				.Where(x => x.CreatedOnUtc.Date == dateTime && x.Status == Enums.NetworkEventStatus.New)
				.GroupBy(x => new GroupedNetworkEventKeyDTO { SimId = x.SimId, Date = x.CreatedOnUtc.Date })
				.Select(x => new GroupedNetworkEventDTO(x))
				.AsNoTracking()
				.ToListAsync();

			return data;
		}

		public async Task SetNetworkEventStatus(IEnumerable<Guid> ids, NetworkEventStatus status)
		{
			// sql query (not ef) to update table with status for specific ids
			await Task.Run(() => { return Task.CompletedTask; });
		}

		public async Task<IEnumerable<SimUsageModel>> ReadUsageBySim(Guid customerId, DateTime dateTime)
		{
			var query = from ne in context.Set<NetworkEvent>()
						join sim in context.Set<Sim>()
							on ne.SimId equals sim.Id
						where
							customerId == sim.CustomerId &&
							ne.CreatedOnUtc.Date == dateTime.Date 
						group ne by sim into simGroup
						select new SimUsageModel
						{
							Sim = simGroup.Key,
							QuotaSum = simGroup.Sum(x => x.Quota)
						};

			return await query
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<IEnumerable<CustomerUsageModel>> ReadUsageByCustomer(DateTime dateTime)
		{
			var query = from ne in context.Set<NetworkEvent>()
						join sim in context.Set<Sim>()
							on ne.SimId equals sim.Id
						join customer in context.Set<Customer>()
							on sim.CustomerId equals customer.Id
						where
							ne.CreatedOnUtc.Date == dateTime.Date
						group ne by customer into customerGroup
						select new CustomerUsageModel
						{
							Customer = new CustomerModel(customerGroup.Key),
							QuotaSum = customerGroup.Sum(x => x.Quota)
						};

			return await query
			   .AsNoTracking()
			   .ToListAsync();
		}
	}
}
