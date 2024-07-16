using Webbing.Assignment.Service.Entities.Abstract;

namespace Webbing.Assignment.Service.Entities;

// Will be use to store the usages of the sim
public class Usage : IEntity
{
    public Guid Id { get; set; }
	public Guid SimId { get; set; }
	public DateTime Date { get; set; }
	public long QuotaSum { get; set; }

	public Sim Sim { get; set; }
}