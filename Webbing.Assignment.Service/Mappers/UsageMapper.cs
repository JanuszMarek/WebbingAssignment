using Webbing.Assignment.Service.DTO;
using Webbing.Assignment.Service.Entities;

namespace Webbing.Assignment.Service.Mappers
{
	public static class UsageMapper
	{
		public static IEnumerable<Usage> Map(IEnumerable<GroupedNetworkEventDTO> dtos)
		{
			foreach (var dto in dtos) 
				yield return Map(dto);
		}

		public static Usage Map(GroupedNetworkEventDTO dto)
		{
			return new Usage
			{
				Date = dto.Date,
				QuotaSum = dto.QuotaSum,
				SimId = dto.SimId,
			};
		}
	}
}
