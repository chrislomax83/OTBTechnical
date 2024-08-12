namespace OTBTechnical.Features.HolidaySearch.Models.Requests;

public record HolidaySearchRequest(string DepartingFrom, string TravellingTo, string DepartureDate, int HolidayDuration) { }