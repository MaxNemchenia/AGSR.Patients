using AGSR.Patients.ServiceContracts.Enums;

namespace AGSR.Patients.ServiceContracts.Dtos.Patient;

public class PatientDto
{
    /// <summary>
    /// Get or set the name of the patient.
    /// </summary>
    public PatientName Name { get; set; }

    /// <summary>
    /// Get or set the gender of the patient.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Get or set the birth date of the patient.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Get or set a value indicating whether the patient is active.
    /// </summary>
    public bool Active { get; set; }
}
