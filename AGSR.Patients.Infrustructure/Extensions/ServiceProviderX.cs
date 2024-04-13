using AGSR.Patients.Infrustructure.Builders.Implementations;
using AGSR.Patients.Infrustructure.Builders.Interfaces;
using AGSR.Patients.Infrustructure.Parsers.Implementations;
using AGSR.Patients.Infrustructure.Parsers.Interfaces;
using AGSR.Patients.Infrustructure.Services.Implementations;
using AGSR.Patients.Infrustructure.Services.Interfaces;
using AGSR.Patients.Infrustructure.Validators;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AGSR.Patients.Infrustructure.Extensions;

public static class ServiceProviderX
{
    /// <summary>
    /// Add AutoMapper profiles from the current domain assemblies to the IServiceCollection.
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
    /// Add the infrustructure services, such as the connection string builder, to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the infrustructure services will be added.</param>
    public static void AddInfrustructureServices(this IServiceCollection services)
    {
        services.AddScoped<IPatientService, PatientService>();
    }

    /// <summary>
    /// Add parsers to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which parsers will be added.</param>
    public static void AddParsers(this IServiceCollection services)
    {
        services.AddScoped<IDateParser, DateParser>();
    }

    /// <summary>
    /// Add builders to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which builders will be added.</param>
    public static void AddBuilders(this IServiceCollection services)
    {
        services.AddScoped<IDateSearchModelBuilder, DateSearchModelBuilder>();
    }

    /// <summary>
    /// Add validators to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which validators will be added.</param>
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<DateSearchRequestValidator>();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }
}
