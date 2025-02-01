using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDB"));
    }
}