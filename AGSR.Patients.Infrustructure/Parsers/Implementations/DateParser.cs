using AGSR.Patients.Infrustructure.Constants;
using AGSR.Patients.Infrustructure.Parsers.Interfaces;
using System.Globalization;

namespace AGSR.Patients.Infrustructure.Parsers.Implementations;

public class DateParser : IDateParser
{
    /// <inheritdoc />
    public (string Format, DateTime? date) ParseDateSearchString(string date)
    {
        foreach (string format in DateFormats.Formats)
        {
            if (DateTime.TryParseExact(
                date,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate))
            {
                return (format, parsedDate);
            }
        }

        return default;
    }
}
