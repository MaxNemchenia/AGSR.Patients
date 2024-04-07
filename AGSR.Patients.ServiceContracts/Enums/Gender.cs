using System.ComponentModel;

namespace AGSR.Patients.ServiceContracts.Enums;

/// <summary>
/// Represents the gender of a person.
/// </summary>
public enum Gender
{
    /// <summary>
    /// Represents a male gender.
    /// </summary>
    [Description("Male")]
    Male,

    /// <summary>
    /// Represents a female gender.
    /// </summary>
    [Description("Female")]
    Female,

    /// <summary>
    /// Represents a gender other than male or female.
    /// </summary>
    [Description("Other")]
    Other,

    /// <summary>
    /// Represents an unknown gender.
    /// </summary>
    [Description("Unknown")]
    Unknown,
}
