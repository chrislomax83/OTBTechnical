using OTBTechnical.Features.FlightSearch;

namespace OTBTechnical.Tests.Features.FlightSearch;

public class AirportRegionsTests
{
    [Theory]
    [InlineData("MAN", "NorthWest")]
    [InlineData("LGW", "London")]
    [InlineData("LTN", "London")]
    public void Should_Return_Airport_Region_From_Code(string airportCode, string expectedRegion)
    {
        var airportRegion = AirportRegions.AirportRegionByCode(airportCode);
        
        Assert.Equal(expectedRegion, airportRegion);
    }

    [Theory]
    [InlineData("London", new string[] {"LGW", "LTN"})]
    [InlineData("NorthWest", new string[] {"MAN"})]
    public void Should_Return_AirportCodes_From_Region(string airportRegion, string[] expectedAirportCodes)
    {
        var airportCodes = AirportRegions.AirportCodesByRegion(airportRegion);

        airportCodes = airportCodes.OrderBy(e => e).ToArray();
        
        Assert.Equal(expectedAirportCodes, airportCodes);
    }
}