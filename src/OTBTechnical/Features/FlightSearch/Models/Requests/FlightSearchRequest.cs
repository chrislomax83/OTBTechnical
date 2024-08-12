using OTBTechnical.Features.Shared.Search;

namespace OTBTechnical.Features.FlightSearch.Models.Requests;

public record FlightSearchRequest(
    string DepartureAirportOrRegionCode, 
    string ArrivalAirportCode,
    string DepartureDate): ISearchRequest
{ }