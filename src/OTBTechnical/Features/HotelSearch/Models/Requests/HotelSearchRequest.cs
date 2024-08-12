using OTBTechnical.Features.Shared.Search;

namespace OTBTechnical.Features.HotelSearch.Models.Requests;

public record HotelSearchRequest(
    int NoOfNights, 
    string ArrivalDate, 
    string DestinationAirport): ISearchRequest { }