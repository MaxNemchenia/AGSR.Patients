using AGSR.Patients.Application.Repositories;
using AGSR.Patients.Infrustructure.Database.Context;
using AGSR.Patients.Infrustructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.Patients.Infrustructure.Database.Extensions;

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
