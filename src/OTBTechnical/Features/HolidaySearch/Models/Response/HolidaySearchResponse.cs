using OTBTechnical.Data.Models;

namespace OTBTechnical.Features.HolidaySearch.Models.Response;

public class HolidaySearchResponse
{

    public HolidaySearchResponse(FlightDataModel flightData, HotelDataModel hotelData)
    {
        FlightData = flightData;
        HotelData = hotelData;
    }
    
    public FlightDataModel FlightData { get; private set; }
    
    public HotelDataModel HotelData { get; private set; }

    public decimal TotalHolidayCost => FlightData.Price + HotelData.TotalCost;
}