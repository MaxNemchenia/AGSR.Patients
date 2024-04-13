using System.ComponentModel;

namespace AGSR.Patients.Infrustructure.Enums;

/// <summary>
/// Represents prefixes for date comparisons.
/// </summary>
public enum DatePrefix
{
    [Description("Equals")]
    /// <summary>
    /// Represents the 'equals' prefix for date comparison.
    /// </summary>
    eq,

    [Description("Not Equals")]
    /// <summary>
    /// Represents the 'not equals' prefix for date comparison.
    /// </summary>
    ne,

    [Description("Greater Than")]
    /// <summary>
    /// Represents the 'greater than' prefix for date comparison.
    /// </summary>
    gt,

    [Description("Greater Or Equals")]
    /// <summary>
    /// Represents the 'greater than or equals' prefix for date comparison.
    /// </summary>
    ge,

    [Description("Less Than")]
    /// <summary>
    /// Represents the 'less than' prefix for date comparison.
    /// </summary>
    lt,

    [Description("Less Or Equal")]
    /// <summary>
    /// Represents the 'less than or equals' prefix for date comparison.
    /// </summary>
    le,

    [Description("Start After")]
    /// <summary>
    /// Represents the 'start after' prefix for date comparison.
    /// </summary>
    sa,

    [Description("Ends Before")]
    /// <summary>
    /// Represents the 'ends before' prefix for date comparison.
    /// </summary>
    eb,

    [Description("Approximately Same")]
    /// <summary>
    /// Represents the 'approximately same' prefix for date comparison.
    /// </summary>
    ap,
}
