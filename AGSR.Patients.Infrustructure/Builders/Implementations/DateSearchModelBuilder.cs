using AGSR.Patients.Infrustructure.Builders.Interfaces;
using AGSR.Patients.Infrustructure.Constants;
using AGSR.Patients.Infrustructure.Enums;
using AGSR.Patients.Infrustructure.Parsers.Interfaces;
using AGSR.Patients.Infrustructure.SearchModels.DateSearch;

namespace AGSR.Patients.Infrustructure.Builders.Implementations;

public class DateSearchModelBuilder : IDateSearchModelBuilder
{
    private readonly IDateParser _dateParser;

    public DateSearchModelBuilder(IDateParser dateParser)
    {
        _dateParser = dateParser;
    }

    /// <inheritdoc />
    public DateSearchModel? Build(string fullDate)
    {
        var prefix = GetPrefix(fullDate[..2]);
        (var format, var date) = _dateParser.ParseDateSearchString(fullDate[2..]);

        if (!date.HasValue)
        {
            return default;
        }

        var endDate = GetEndDate(format, date.Value);

        DateSearchModel model = new()
        {
            Prefix = prefix,
            DatePeriod = new DatePeriod(date.Value, endDate),
        };

        return model;
    }

    private static DatePrefix GetPrefix(string prefixStr)
    {
        return Enum.Parse<DatePrefix>(prefixStr);
    }

    private static DateTime GetEndDate(string format, DateTime date)
    {
        return format switch
        {
            DateFormats.YearOnlyFormat => date.AddYears(1).AddSeconds(-1),
            DateFormats.MonthFormat => date.AddMonths(1).AddSeconds(-1),
            DateFormats.DayFormat => date.AddDays(1).AddSeconds(-1),
            DateFormats.HourFormat => date.AddHours(1).AddSeconds(-1),
            DateFormats.MinuteFormat => date.AddMinutes(1).AddSeconds(-1),
            DateFormats.SecondFormat => date.AddSeconds(1),
            DateFormats.MillisecondFormat => date.AddMilliseconds(1),
            _ => throw new NotSupportedException()
        };
    }
}
