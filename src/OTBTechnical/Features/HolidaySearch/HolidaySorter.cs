using OTBTechnical.Features.HolidaySearch.Models.Response;

namespace OTBTechnical.Features.HolidaySearch;

public static class HolidaySorter
{
    public static IReadOnlyList<HolidaySearchResponse> OrderByTotalHolidayCost(
        this IReadOnlyList<HolidaySearchResponse> holidays)
    {
        return holidays.OrderBy(e => e.TotalHolidayCost).ToList().AsReadOnly();
    }
}