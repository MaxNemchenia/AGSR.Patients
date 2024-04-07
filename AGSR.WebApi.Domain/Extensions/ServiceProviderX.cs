using AGSR.WebApi.Domain.Context;
using AGSR.WebApi.Domain.Repositories.Implementations;
using AGSR.WebApi.Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.WebApi.Domain.Extensions;

public static class ServiceProviderX
{
    /// <summary>
    /// Adds the patient repository to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the repository will be added.</param>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
    }

    /// <summary>
    /// Adds the configuration database context to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the database context will be added.</param>
    public static void AddConfigDbContext(this IServiceCollection services)
    {
        services.AddDbContext<ConfigContext>();
    }
}
