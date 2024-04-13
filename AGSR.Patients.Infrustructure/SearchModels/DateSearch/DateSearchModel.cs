using AGSR.Patients.Infrustructure.Enums;

namespace AGSR.Patients.Infrustructure.SearchModels.DateSearch;

public class DateSearchModel
{
    /// <summary>
    /// Gets or initializes the date prefix.
    /// </summary>
    public DatePrefix Prefix { get; set; }

    /// <summary>
    /// Gets or initializes the date period.
    /// </summary>
    public DatePeriod? DatePeriod { get; set; }
}
