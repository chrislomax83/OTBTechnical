namespace OTBTechnical.Features.FlightSearch;

public static class AirportsTermMapper
{
    public static string[] AirportsFromSearchTerm(string airportCode)
    {
        // Check to see if the airport search term is a region lookup
        var airportCodesFromRegion = AirportRegions.AirportCodesByRegion(airportCode);

        return airportCodesFromRegion.Length > 0 ? airportCodesFromRegion : [airportCode];
    }
}