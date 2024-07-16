using Microsoft.EntityFrameworkCore;
using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Entities;
using Webbing.Assignment.Service.Models;
using Webbing.Assignment.Service.Repository.Abstract;

namespace Webbing.Assignment.Service.Repository
{
    public class UsageRepository : BaseRepository<Usage, ApplicationDbContext>, IUsageRepository
	{
		public UsageRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

		public async Task Create(IEnumerable<Usage> usages)
		{
			await dbSet.AddRangeAsync(usages);
		}

		public async Task<IEnumerable<SimUsageModel>> ReadUsageBySim(Guid customerId, DateTime fromDate, DateTime toDate)
		{
			var query = from usage in context.Set<Usage>()
						join sim in context.Set<Sim>()
							on usage.SimId equals sim.Id
						where
							customerId == sim.CustomerId &&
							usage.Date >= fromDate &&
							usage.Date <= toDate
						group usage by sim into simGroup
						select new SimUsageModel
						{
							Sim = simGroup.Key,
							QuotaSum = simGroup.Sum(x => x.QuotaSum)
						};

			return await query
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<IEnumerable<CustomerUsageModel>> ReadUsageByCustomer(DateTime fromDate, DateTime toDate)
		{
			var query = await context.Usages
				.Where(u => u.Date >= fromDate && u.Date <= toDate)
				.Join(context.Sims,
					usage => usage.SimId,
					sim => sim.Id,
					(usage, sim) => new { Usage = usage, Sim = sim })
				.Join(context.Customers,
					usageSim => usageSim.Sim.CustomerId,
					customer => customer.Id,
					(usageSim, customer) => new { usageSim.Usage, usageSim.Sim, Customer = customer })
				.GroupBy(x => x.Sim.Customer)
				.Select(group => new CustomerUsageModel
				{
					Customer = new CustomerModel(group.Key),
					QuotaSum = group.Sum(x => x.Usage.QuotaSum),
					SimCount = group.Select(x => x.Sim.Id).Distinct().Count()
				})
				.AsNoTracking()
				.ToListAsync();

			return query;
		}
	}
}
