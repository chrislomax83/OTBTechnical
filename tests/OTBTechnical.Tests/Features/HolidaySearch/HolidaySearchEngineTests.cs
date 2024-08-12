using OTBTechnical.Features.FlightSearch;
using OTBTechnical.Features.HolidaySearch;
using OTBTechnical.Features.HolidaySearch.Models.Requests;
using OTBTechnical.Features.HotelSearch;

namespace OTBTechnical.Tests.Features.HolidaySearch;

public class HolidaySearchEngineTests
{
    [Fact]
    public async Task Should_Return_Any_Elements_For_Holiday_Search_Request()
    {
        var flightSearchEngine = new FlightSearchEngine();

        var hotelSearchEngine = new HotelSearchEngine();

        var holidaySearchEngine = new HolidaySearchEngine(flightSearchEngine, hotelSearchEngine);

        var holidaySearchRequest = new HolidaySearchRequest("MAN", "AGP", "2023/07/01", 7);

        var results = await holidaySearchEngine.Search(holidaySearchRequest);
        
        Assert.True(results.Count > 0);
    }
}