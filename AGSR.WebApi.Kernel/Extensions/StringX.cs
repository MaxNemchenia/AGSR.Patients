namespace AGSR.WebApi.Kernel.Extensions;

public static class StringX
{
    private static char Separator => ' ';

    public static IEnumerable<string> SplitString(this string concatenatedString)
        => concatenatedString.Split(Separator);

    public static string ConcatenateStrings(this IEnumerable<string> strings)
        => string.Join(Separator, strings);
}
