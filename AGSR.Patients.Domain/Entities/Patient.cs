using AGSR.Patients.ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;

namespace AGSR.Patients.Domain.Entities;

public class Patient
{
    /// <summary>
    /// Gets or sets the unique identifier of the patient.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the usage status.
    /// </summary>
    public string Use { get; set; }

    /// <summary>
    /// Gets or sets the gender of the patient.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Gets or sets the birth date of the patient.
    /// </summary>
    [Required]
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the patient is active.
    /// </summary>
    [Required]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the family name of the patient.
    /// </summary>
    [Required]
    public string Family { get; set; }

    /// <summary>
    /// Gets or sets the given name(s) of the patient.
    /// </summary>
    public string Given { get; set; }
}

