using FluentValidation;
using OTBTechnical.Features.HolidaySearch.Models.Requests;
using OTBTechnical.Validators;

namespace OTBTechnical.Features.HolidaySearch.Validators;

public class HolidaySearchRequestValidator : AbstractValidator<HolidaySearchRequest>
{
    public HolidaySearchRequestValidator()
    {
        RuleFor(e => e.DepartureDate).Must(DateValidators.BeAValidDateOnly).WithMessage("Invalid departure date");
        RuleFor(e => e.TravellingTo).Length(3).WithMessage("Invalid destination airport code");
        RuleFor(e => e.HolidayDuration).GreaterThan(0).WithMessage("Invalid holiday duration");
        RuleFor(e => e.DepartingFrom).NotEmpty().WithMessage("Invalid departure airport");
    }
}