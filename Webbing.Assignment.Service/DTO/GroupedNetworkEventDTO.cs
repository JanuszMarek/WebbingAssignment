using Webbing.Assignment.Service.Entities;

namespace Webbing.Assignment.Service.DTO
{
	public class GroupedNetworkEventDTO
	{
		public Guid SimId { get; set; }
		public DateTime Date { get; set; }
		public long QuotaSum { get; set; }
		public IEnumerable<Guid> NetworkEventIds { get; set; }

        public GroupedNetworkEventDTO(IGrouping<GroupedNetworkEventKeyDTO, NetworkEvent> groupedNetworkEvents)
        {
			
			SimId = groupedNetworkEvents.Key.SimId;
			Date = groupedNetworkEvents.Key.Date;
			QuotaSum = groupedNetworkEvents.Sum(x => x.Quota);
			NetworkEventIds = groupedNetworkEvents.Select(x => x.Id);
        } 
    }
}
