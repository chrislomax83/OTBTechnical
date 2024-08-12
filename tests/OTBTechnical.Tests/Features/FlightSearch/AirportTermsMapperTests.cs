using OTBTechnical.Features.FlightSearch;

namespace OTBTechnical.Tests.Features.FlightSearch;

public class AirportTermsMapperTests
{

    [Theory] 
    [InlineData("MAN", new string[] {"MAN"})]
    [InlineData("LTN", new string[] {"LTN"})]
    [InlineData("LGW", new string[] {"LGW"})]
    public void Should_Get_Airport_Code_From_Single_Input(string inputCode, string[] expectedCodes)
    {
        var actualAirportCodes = AirportsTermMapper.AirportsFromSearchTerm(inputCode);
        
        Assert.Equal(expectedCodes, actualAirportCodes);
    }

    [Theory]
    [InlineData("London", new string[] {"LGW", "LTN"})]
    [InlineData("NorthWest", new string[] {"MAN"})]
    public void Should_Get_Airport_Codes_From_Region(string inputRegion, string[] expectedCodes)
    {
        var actualAirportCodes = AirportsTermMapper.AirportsFromSearchTerm(inputRegion);

        actualAirportCodes = actualAirportCodes.OrderBy(e => e).ToArray();
        
        Assert.Equal(expectedCodes, actualAirportCodes);
    }
    
}