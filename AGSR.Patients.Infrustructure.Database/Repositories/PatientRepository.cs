using AGSR.Patients.Application.Repositories;
using AGSR.Patients.Domain.Entities;
using AGSR.Patients.Infrustructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace AGSR.Patients.Infrustructure.Database.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly ConfigContext _context;

    /// <summary>
    /// Constructor for PatientRepository.
    /// </summary>
    /// <param name="context">The database context.</param>
    public PatientRepository(ConfigContext context)
        => _context = context;

    /// <inheritdoc />
    public IQueryable<Patient> Query()
        => _context.Patients.AsNoTracking();

    /// <inheritdoc />
    public Task<Patient?> ReadAsync(Guid id)
        => _context.Patients.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

    /// <inheritdoc />
    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(IEnumerable<Patient> patients)
    {
        await _context.Patients.AddRangeAsync(patients);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Patient patient)
    {
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }
}

