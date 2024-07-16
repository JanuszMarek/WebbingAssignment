using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Entities;
using Webbing.Assignment.Service.LogicServices.Abstract;
using Webbing.Assignment.Service.Mappers;
using Webbing.Assignment.Service.Models;
using Webbing.Assignment.Service.Repository.Abstract;

namespace Webbing.Assignment.Service.LogicService
{
	public class UsageLogicService : IUsageLogicService
	{
		private readonly INetworkEventRepository networkEventRepository;
		private readonly IUsageRepository usageRepository;

		public UsageLogicService(INetworkEventRepository networkEventRepository, IUsageRepository usageRepository)
		{
			this.networkEventRepository = networkEventRepository;
			this.usageRepository = usageRepository;
		}

		public async Task StoreUsageForDate(DateTime dateTime)
		{
			var usages = await GetUsageFromGroupedNetworkEventsByDate(dateTime);
			await usageRepository.Create(usages);
			await usageRepository.SaveChanges();
		}

		public async Task<IEnumerable<CustomerUsageModel>> GetUsageByCustomer(DateTime from, DateTime? to = null)
		{
			to ??= DateTime.UtcNow;

			var usages = (await usageRepository.ReadUsageByCustomer(from, to.Value)).ToList();

			if (to.Value.Date == DateTime.UtcNow.Date)
			{
				var todaysUsages = await networkEventRepository.ReadUsageByCustomer(to.Value.Date);
				usages.AddRange(todaysUsages);
			}

			return usages;
		}

		public async Task<IEnumerable<SimUsageModel>> GetUsageBySim(Guid customerId, DateTime from, DateTime? to = null)
		{
			to ??= DateTime.UtcNow;

			var usages = (await usageRepository.ReadUsageBySim(customerId, from, to.Value)).ToList();

			if (to.Value.Date == DateTime.UtcNow.Date)
			{
				var todaysUsages = await networkEventRepository.ReadUsageBySim(customerId, to.Value.Date);
				usages.AddRange(todaysUsages);
			}

			return usages;
		}

		private async Task<IEnumerable<Usage>> GetUsageFromGroupedNetworkEventsByDate(DateTime dateTime)
		{
			var groupedEvents = await networkEventRepository.ReadGroupedNetworkEventsByDate(dateTime);
			await networkEventRepository.SetNetworkEventStatus(groupedEvents.SelectMany(x => x.NetworkEventIds), Enums.NetworkEventStatus.Proceseed);
			return UsageMapper.Map(groupedEvents);
		}
	}
}
