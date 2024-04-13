using AGSR.Patients.Infrustructure.Enums;
using AGSR.Patients.Infrustructure.Requests;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AGSR.Patients.Infrustructure.Validators;

public class DateSearchRequestValidator : AbstractValidator<DateSearchRequest>
{
    public DateSearchRequestValidator()
    {
        RuleFor(x => x.Dates).NotEmpty().WithMessage("Dates are required");
        RuleForEach(x => x.Dates).Must(BeValidDateTimeFormat).WithMessage("Invalid date format");
    }

    private bool BeValidDateTimeFormat(string date)
    {
        var datePrefixRegex = string.Join("|", Enum.GetNames(typeof(DatePrefix)).Select(e => e.ToLower()));
        var regexPattern
            = @$"^({datePrefixRegex})\\d{4}-\\d{2}-\\d{2}T\\d{2}:\\d{2}:\\d{2}.\\d{4}(Z|([+-]\\d{2}:\\d{2}))?$";
        var regexPattern1 = $"^({datePrefixRegex})"
            + @"(\d{4}(-\d{2}){0,2}(T\d{2}(:\d{2}(:\d{2}(\.\d{1,4})?)?)?(Z|(\+|-)\d{2}:\d{2})?)?)?$";
        
        return Regex.IsMatch(date, regexPattern1);
    }
}
