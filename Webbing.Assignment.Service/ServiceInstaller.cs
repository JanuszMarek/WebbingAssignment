using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Webbing.Assignment.Service;

public static class ServiceInstaller
{
    public static IServiceCollection AddAppService(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemory"));
        
        return services;
    }
}