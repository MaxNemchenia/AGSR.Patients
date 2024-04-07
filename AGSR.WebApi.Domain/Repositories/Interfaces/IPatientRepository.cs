using AGSR.WebApi.Domain.Entities;

namespace AGSR.WebApi.Domain.Repositories.Interfaces;

public interface IPatientRepository
{
    /// <summary>
    /// Get a queryable collection of patients.
    /// </summary>
    /// <returns>A queryable collection of patients.</returns>
    IQueryable<Patient> Query();

    /// <summary>
    /// Get a patient by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the patient.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation that retrieves the patient.</returns>
    Task<Patient?> ReadAsync(Guid id);

    /// <summary>
    /// Add a new patient to the database asynchronously.
    /// </summary>
    /// <param name="patient">The patient to be added.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation of adding the patient.</returns>
    Task AddAsync(Patient patient);

    /// <summary>
    /// Add multiple new patients to the database asynchronously.
    /// </summary>
    /// <param name="patients">The collection of patients to be added.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation of adding the patients.</returns>
    Task AddAsync(IEnumerable<Patient> patients);

    /// <summary>
    /// Update an existing patient in the database asynchronously.
    /// </summary>
    /// <param name="patient">The patient to be updated.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation of updating the patient.</returns>
    Task UpdateAsync(Patient patient);

    /// <summary>
    /// Delete an existing patient from the database asynchronously.
    /// </summary>
    /// <param name="patient">The patient to be deleted.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation of deleting the patient.</returns>
    Task DeleteAsync(Patient patient);
}

