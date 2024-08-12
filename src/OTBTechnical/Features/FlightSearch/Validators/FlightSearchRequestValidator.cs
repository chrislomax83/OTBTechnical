using FluentValidation;
using OTBTechnical.Features.FlightSearch.Models.Requests;
using OTBTechnical.Validators;

namespace OTBTechnical.Features.FlightSearch.Validators;

public class FlightSearchRequestValidator : AbstractValidator<FlightSearchRequest>
{
    public FlightSearchRequestValidator()
    {
        RuleFor(e => e.ArrivalAirportCode).Length(3).WithMessage("Invalid arrival airport");
        RuleFor(e => e.DepartureDate).Must(DateValidators.BeAValidDateOnly).WithMessage("Invalid departure date");
        RuleFor(e => e.DepartureAirportOrRegionCode).NotEmpty().WithMessage("Invalid departure airport");
    }
    
}