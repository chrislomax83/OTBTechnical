using OTBTechnical.Data.Models;
using OTBTechnical.Features.FlightSearch.Models.Requests;
using OTBTechnical.Features.Shared.DataFilter;

namespace OTBTechnical.Features.FlightSearch;

public class FlightDataFilter(FlightSearchRequest request, IReadOnlyList<FlightDataModel> data)
    : AbstractDataFilter<FlightSearchRequest, FlightDataModel>(request, data)
{
    
    protected override void ApplyFilters()
    {
        FilterByDepartureDate();
        FilterByArrivalAirport();
        FilterByDepartureAirportOrRegion();
    }

    private void FilterByDepartureDate()
    {
        var requestDepartureDate = DateOnly.Parse(Request.DepartureDate);
        
        FilteredData = FilteredData
            .Where(e => e.DepartureDate.Equals(requestDepartureDate));
    }

    private void FilterByDepartureAirportOrRegion()
    {
        if (Request.DepartureAirportOrRegionCode.Equals("Any", StringComparison.InvariantCultureIgnoreCase)) return;
        
        var airports = AirportsTermMapper.AirportsFromSearchTerm(Request.DepartureAirportOrRegionCode);

        FilteredData = FilteredData
            .Where(e => airports.Contains(e.From, StringComparer.InvariantCultureIgnoreCase));
    }

    private void FilterByArrivalAirport()
    {
        FilteredData = FilteredData
            .Where(e => e.To.Equals(Request.ArrivalAirportCode, StringComparison.InvariantCultureIgnoreCase));
    }
}