namespace AGSR.Patients.Infrustructure.Constants;

public class DateFormats
{
    public const string YearOnlyFormat = "yyyy";

    public const string MonthFormat = "yyyy-MM";

    public const string DayFormat = "yyyy-MM-dd";

    public const string HourFormat = "yyyy-MM-ddTHH";

    public const string MinuteFormat = "yyyy-MM-ddTHH:mm";

    public const string SecondFormat = "yyyy-MM-ddTHH:mm:ss";

    public const string MillisecondFormat = "yyyy-MM-ddTHH:mm:ss.ffff";

    public static string[] Formats
        => [YearOnlyFormat, MonthFormat, DayFormat, HourFormat, MinuteFormat, SecondFormat, MillisecondFormat];
}
