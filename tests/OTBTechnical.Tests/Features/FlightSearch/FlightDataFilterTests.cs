using OTBTechnical.Data;
using OTBTechnical.Features.FlightSearch;
using OTBTechnical.Features.FlightSearch.Models.Requests;

namespace OTBTechnical.Tests.Features.FlightSearch;

public class FlightDataFilterTests
{
    [Theory]
    [InlineData("MAN", "TFS", "2023-07-01")]
    [InlineData("MAN", "AGP", "2023-07-01")]
    public async Task Should_Return_Filtered_List_With_Any_Elements_From_Flight_Search_Request(
        string departureAirport, string arrivalAirport, string departureDate)
    {
        var flightRequest = new FlightSearchRequest(departureAirport, arrivalAirport, departureDate);
        var flightDataLoader = new FlightDataLoader();
        var flightData = await flightDataLoader.GetData();
        
        Assert.True(flightData.Count > 0);

        var flightFilter = new FlightDataFilter(flightRequest, flightData);
        var results = flightFilter.GetResults();

        Assert.True(results.Count > 0);
    }
}