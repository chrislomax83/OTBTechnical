using FluentValidation;
using OTBTechnical.Features.HotelSearch.Models.Requests;
using OTBTechnical.Validators;

namespace OTBTechnical.Features.HotelSearch.Validators;

public class HotelSearchRequestValidator: AbstractValidator<HotelSearchRequest>
{
    public HotelSearchRequestValidator()
    {
        RuleFor(e => e.ArrivalDate).Must(DateValidators.BeAValidDateOnly).WithMessage("Invalid arrival date");
        RuleFor(e => e.DestinationAirport).Length(3).WithMessage("Invalid destination airport");
        RuleFor(e => e.NoOfNights).GreaterThan(0).WithMessage("Invalid number of nights");
    }
}