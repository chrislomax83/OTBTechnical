using OTBTechnical.Features.FlightSearch;
using OTBTechnical.Features.FlightSearch.Models.Requests;

namespace OTBTechnical.Tests.Features.FlightSearch;

public class FlightSearchEngineTests
{
    [Theory]
    [InlineData("MAN", "TFS", "2023-07-01",  1)]
    [InlineData("MAN", "AGP", "2023-07-01",  1)]
    [InlineData("LGW", "PMI", "2023-06-15", 1)]
    [InlineData("LGW", "AGP", "2023-07-01", 2)]
    public async Task Should_Return_All_Flights_For_Search_Term(
        string departureAirport, string arrivalAirport, string departureDate, int expectedElements)
    {
        var flightRequest = new FlightSearchRequest(departureAirport, arrivalAirport, departureDate);

        var searchEngine = new FlightSearchEngine();
        
        var searchResults = await searchEngine.Search(flightRequest);
        
        Assert.Equal(expectedElements, searchResults.Count);
    }
}