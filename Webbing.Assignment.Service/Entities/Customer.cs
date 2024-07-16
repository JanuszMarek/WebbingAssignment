using Webbing.Assignment.Service.Entities.Abstract;

namespace Webbing.Assignment.Service.Entities;

public class Customer : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

	public ICollection<Sim> Sims { get; set; }
}