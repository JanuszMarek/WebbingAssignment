using Webbing.Assignment.Service.Entities.Abstract;

namespace Webbing.Assignment.Service.Entities;

public class Sim : IEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

	public Customer Customer { get; set; }
	public ICollection<Usage> Usages { get; set; }
	public ICollection<NetworkEvent> NetworkEvents { get; set; }
}