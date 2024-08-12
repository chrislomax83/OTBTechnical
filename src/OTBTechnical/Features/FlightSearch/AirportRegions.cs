using OTBTechnical.Features.FlightSearch.Models;

namespace OTBTechnical.Features.FlightSearch;

public static class AirportRegions
{
    private static IReadOnlyList<AirportRegionModel> AirportRegionsList =>
    [
        new("MAN", "NorthWest"),
        new("LTN", "London"),
        new("LGW", "London")
    ];
    
    public static string AirportRegionByCode(string airportCode)
    {
        return AirportRegionsList
            .FirstOrDefault(e => e.AirportCode.Equals(airportCode, StringComparison.InvariantCultureIgnoreCase))
            ?.AirportRegion ?? string.Empty;
    }

    public static string[] AirportCodesByRegion(string region)
    {
        return AirportRegionsList
            .Where(e => e.AirportRegion.Equals(region, StringComparison.InvariantCultureIgnoreCase))
            .Select(e => e.AirportCode)
            .ToArray();
    }
}