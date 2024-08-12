using OTBTechnical.Data.Models;
using OTBTechnical.Features.FlightSearch.Models.Requests;
using OTBTechnical.Features.HotelSearch.Models.Requests;
using OTBTechnical.Features.Shared.DataFilter;

namespace OTBTechnical.Features.HotelSearch;

public class HotelDataFilter(HotelSearchRequest request, IReadOnlyList<HotelDataModel> data)
    : AbstractDataFilter<HotelSearchRequest, HotelDataModel>(request, data)
{
    
    protected override void ApplyFilters()
    {
        FilterByNoOfNights();
        FilterByArrivalDate();
        FilterByDestinationAirport();
    }

    private void FilterByNoOfNights()
    {
        FilteredData = FilteredData.Where(e => e.Nights.Equals(Request.NoOfNights));
    }

    private void FilterByArrivalDate()
    {
        var requestArrivalDate = DateOnly.Parse(Request.ArrivalDate);
        FilteredData = FilteredData.Where(e => e.ArrivalDate.Equals(requestArrivalDate));
    }

    private void FilterByDestinationAirport()
    {
        FilteredData = FilteredData.Where(e => e.LocalAirports.Contains(Request.DestinationAirport));
    }
}