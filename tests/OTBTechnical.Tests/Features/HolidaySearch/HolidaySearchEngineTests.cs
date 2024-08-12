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
    
    [Theory]
    [InlineData("MAN", "AGP", "2024/07/01", 7)]
    [InlineData("London", "PMI", "2024/06/15", 10)]
    [InlineData("Any", "LPA", "2024/11/10", 14)]
    public async Task Should_Return_No_Elements_For_Holiday_Search_Request(
        string departingFrom, string travellingTo, string departureDate, int holidayDuration)
    {
        var flightSearchEngine = new FlightSearchEngine();

        var hotelSearchEngine = new HotelSearchEngine();

        var holidaySearchEngine = new HolidaySearchEngine(flightSearchEngine, hotelSearchEngine);

        var holidaySearchRequest = new HolidaySearchRequest(departingFrom, travellingTo, departureDate, holidayDuration);

        var results = await holidaySearchEngine.Search(holidaySearchRequest);
        
        Assert.Empty(results);
    }
}