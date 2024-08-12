using OTBTechnical.Data.Models;
using OTBTechnical.Features.HotelSearch.Models.Requests;

namespace OTBTechnical.Features.HotelSearch;

public class HotelDataFilter
{
    private readonly IReadOnlyList<HotelDataModel> _data;
    private IQueryable<HotelDataModel> _filteredData = null!;

    private readonly HotelSearchRequest _request;
    
    public HotelDataFilter(HotelSearchRequest request, IReadOnlyList<HotelDataModel> data)
    {
        _data = data;
        _request = request;
        _filteredData = data.AsQueryable();
    }
    
    public List<HotelDataModel> GetResults()
    {
        ApplyFilters();
        return _filteredData.ToList();
    }

    private void ApplyFilters()
    {
        FilterByNoOfNights();
        FilterByArrivalDate();
        FilterByDestinationAirport();
    }

    private void FilterByNoOfNights()
    {
        _filteredData = _filteredData.Where(e => e.Nights.Equals(_request.NoOfNights));
    }

    private void FilterByArrivalDate()
    {
        var requestArrivalDate = DateOnly.Parse(_request.ArrivalDate);
        _filteredData = _filteredData.Where(e => e.ArrivalDate.Equals(requestArrivalDate));
    }

    private void FilterByDestinationAirport()
    {
        _filteredData = _filteredData.Where(e => e.LocalAirports.Contains(_request.DestinationAirport));
    }
}