using AGSR.Patients.Kernel.Builders.Implementations;
using AGSR.Patients.Kernel.Builders.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.Patients.Kernel.Extensions;

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
