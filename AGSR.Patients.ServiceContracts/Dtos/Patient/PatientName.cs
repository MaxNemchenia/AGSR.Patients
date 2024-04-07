namespace AGSR.Patients.ServiceContracts.Dtos.Patient;

public class PatientName
{
    /// <summary>
    /// Get or set the unique identifier of the patient's name.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Get or set the usage status of the name.
    /// </summary>
    public string Use { get; set; }

    /// <summary>
    /// Get or set the family name of the patient.
    /// </summary>
    public string Family { get; set; }

    /// <summary>
    /// Get or set the given name(s) of the patient.
    /// </summary>
    public IEnumerable<string> Given { get; set; }
}
