using AGSR.WebApi.Kernel.Builders.Implementations;
using AGSR.WebApi.Kernel.Builders.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.WebApi.Kernel.Extensions;

public static class ServiceProviderX
{
    /// <summary>
    /// Adds the kernel services, such as the connection string builder, to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the kernel services will be added.</param>
    public static void AddKernelServices(this IServiceCollection services)
    {
        services.AddTransient<IConnectionStringBuilder, ConnectionStringBuilder>();
    }
}
