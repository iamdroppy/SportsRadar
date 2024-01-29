using Microsoft.Extensions.DependencyInjection;

namespace SportRadar.WorldCupFootball.Implementation;

public static class ServiceExpose
{
    public static IServiceCollection AddWorldCupFootball(this IServiceCollection services)
    {
        services.AddSingleton<IGroup, Group>();
        return services;
    }
}