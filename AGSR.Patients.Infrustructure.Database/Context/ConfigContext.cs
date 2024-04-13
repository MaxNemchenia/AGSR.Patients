using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Kernel.Builders.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AGSR.Patients.Infrustructure.Database.Context;

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
