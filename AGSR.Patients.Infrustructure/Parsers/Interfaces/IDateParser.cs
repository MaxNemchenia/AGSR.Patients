namespace AGSR.Patients.Infrustructure.Parsers.Interfaces;

public interface IDateParser
{
    /// <summary>
    /// Parses the date search string to extract the format and date.
    /// </summary>
    /// <param name="date">The date search string to be parsed.</param>
    /// <returns>A tuple containing the format and the parsed date, if successful; otherwise, null.</returns>
    (string Format, DateTime? date) ParseDateSearchString(string date);
}
