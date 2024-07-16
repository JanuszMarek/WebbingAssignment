using Webbing.Assignment.Service.Entities;

namespace Webbing.Assignment.Service.Models;

public class CustomerModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public CustomerModel()
    {
			
    }

    public CustomerModel(Customer customer)
    {
        Id = customer.Id;
        Name = customer.Name;
    }
}