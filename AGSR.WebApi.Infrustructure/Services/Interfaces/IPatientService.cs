using AGSR.Patients.ServiceContracts.Dtos.Patient;

namespace AGSR.WebApi.Infrustructure.Services.Interfaces;

public interface IPatientService
{
    /// <summary>
    /// Get a list collection of patient data transfer objects.
    /// </summary>
    /// <returns>A queryable collection of <see cref="PatientDto"/> objects.</returns>
    IEnumerable<PatientDto> Query();

    /// <summary>
    /// Get a <see cref="PatientDto"/> object by its ID.
    /// </summary>
    /// <param name="id">The ID of the patient to retrieve.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the <see cref="PatientDto"/> object.</returns>
    Task<PatientDto> GetAsync(Guid id);

    /// <summary>
    /// Add a new patient using the provided <see cref="PatientDto"/> object.
    /// </summary>
    /// <param name="patientDto">The patient data transfer object to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddAsync(PatientDto patientDto);

    /// <summary>
    /// Add multiple patients using the provided collection of <see cref="PatientDto"/> objects.
    /// </summary>
    /// <param name="patientDtos">The collection of patient data transfer objects to add.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task AddAsync(IEnumerable<PatientDto> patientDtos);

    /// <summary>
    /// Update an existing patient using the provided <see cref="PatientDto"/> object.
    /// </summary>
    /// <param name="patientDto">The patient data transfer object with updated information.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task UpdateAsync(PatientDto patientDto);

    /// <summary>
    /// Delete a patient by its ID.
    /// </summary>
    /// <param name="id">The ID of the patient to delete.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task DeleteAsync(Guid id);
}

