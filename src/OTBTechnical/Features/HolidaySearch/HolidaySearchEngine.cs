using FluentValidation;
using OTBTechnical.Data.Models;
using OTBTechnical.Features.FlightSearch;
using OTBTechnical.Features.FlightSearch.Models.Requests;
using OTBTechnical.Features.HolidaySearch.Models.Requests;
using OTBTechnical.Features.HolidaySearch.Models.Response;
using OTBTechnical.Features.HolidaySearch.Validators;
using OTBTechnical.Features.HotelSearch;
using OTBTechnical.Features.HotelSearch.Models.Requests;

namespace OTBTechnical.Features.HolidaySearch;

public class HolidaySearchEngine
{

    private readonly FlightSearchEngine _flightSearchEngine;
    private readonly HotelSearchEngine _hotelSearchEngine;

    public HolidaySearchEngine(
        FlightSearchEngine flightSearchEngine,
        HotelSearchEngine hotelSearchEngine)
    {
        _flightSearchEngine = flightSearchEngine;
        _hotelSearchEngine = hotelSearchEngine;
    }

    public async Task<IReadOnlyList<HolidaySearchResponse>> Search(HolidaySearchRequest request)
    {

        var holidaySearchValidator = new HolidaySearchRequestValidator();

        await holidaySearchValidator.ValidateAndThrowAsync(request);
        
        var flightSearchRequest =
            new FlightSearchRequest(request.DepartingFrom, request.TravellingTo, request.DepartureDate);

        var hotelSearchRequest =
            new HotelSearchRequest(request.HolidayDuration, request.DepartureDate, request.TravellingTo);

        var flightResults = await _flightSearchEngine.Search(flightSearchRequest);

        var hotelResults = await _hotelSearchEngine.Search(hotelSearchRequest);

        var combinedSearchResponse = CreateSearchResponse(flightResults, hotelResults);
        
        return combinedSearchResponse.OrderByTotalHolidayCost();
    }

    private IReadOnlyList<HolidaySearchResponse> CreateSearchResponse(
        List<FlightDataModel> flightData,
        List<HotelDataModel> hotelData)
    {
        var joinedData = from hotelDataItems in hotelData
            from flightDataItems in flightData
            select new HolidaySearchResponse(flightDataItems, hotelDataItems);

        return joinedData.ToList().AsReadOnly();
    }
}
