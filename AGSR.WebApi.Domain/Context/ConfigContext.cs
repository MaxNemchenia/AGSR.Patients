using AGSR.WebApi.Domain.Entities;
using AGSR.WebApi.Kernel.Builders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AGSR.WebApi.Domain.Context;

public class ConfigContext : DbContext
{
    private readonly IConnectionStringBuilder _connectionStringBuilder;

    public ConfigContext(
        DbContextOptions<ConfigContext> options,
        IConnectionStringBuilder connectionStringBuilder)
        : base(options)
    {
        _connectionStringBuilder = connectionStringBuilder;
    }

    public DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder is { IsConfigured: false })
        {
            optionsBuilder.UseSqlServer(_connectionStringBuilder.BuildConnectionString());
        }
    }
}
