using Webbing.Assignment.Service.Entities;

namespace Webbing.Assignment.Service.Models;

public class SimModel
{
    public SimModel()
    {
			
    }

    public SimModel(Sim sim)
	{
		Id = sim.Id;
		CustomerId = sim.CustomerId;
	}

	public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
}