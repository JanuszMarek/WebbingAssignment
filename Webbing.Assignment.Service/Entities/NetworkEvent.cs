using Webbing.Assignment.Service.Entities.Abstract;
using Webbing.Assignment.Service.Enums;

namespace Webbing.Assignment.Service.Entities;

public class NetworkEvent : IEntity
{
    // For EF
    public Guid Id { get; set; }

    // Will be use to identify the sim
    public Guid SimId { get; set; }

    public Guid SessionId { get; set; }

    public long Quota { get; set; }

    // The date of the current network event
    public DateTime CreatedOnUtc { get; set; }
	public NetworkEventStatus Status { get; set; }

	public Sim Sim { get; set; }
}