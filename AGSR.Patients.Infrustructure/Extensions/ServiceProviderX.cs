using AGSR.Patients.Infrustructure.Services.Implementations;
using AGSR.Patients.Infrustructure.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AGSR.Patients.Infrustructure.Extensions;

public static class ServiceProviderX
{
    /// <summary>
    /// Adds AutoMapper profiles from the current domain assemblies to the IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to which the AutoMapper profiles will be added.</param>
    public static void AddAutoMapperProfiles(this IServiceCollection services)
    {
        var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        var definedTypes = domainAssemblies
            .Where(a => a.DefinedTypes.Any(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t)))
            .SelectMany(x => x.DefinedTypes).Distinct().ToList();

        var assemblies = definedTypes.Select(x => x.Assembly).Distinct();
        services.AddAutoMapper(assemblies);
    }

    /// <summary>
    /// Adds the infrustructure services, such as the connection string builder, to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the infrustructure services will be added.</param>
    public static void AddInfrustructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
    }
}
