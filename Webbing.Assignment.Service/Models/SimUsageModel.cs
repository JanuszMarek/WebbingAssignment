using Webbing.Assignment.Service.Entities;

namespace Webbing.Assignment.Service.DTO
{
	public class SimUsageModel
	{
		public Sim? Sim { get; set; }
		public long QuotaSum { get; set; }
	}
}
