using OTBTechnical.Data;
using OTBTechnical.Features.HotelSearch;
using OTBTechnical.Features.HotelSearch.Models.Requests;

namespace OTBTechnical.Tests.Features.HotelSearch;

public class HotelDataFilterTests
{
    [Theory]
    [InlineData(7, "2022-11-05", "TFS")]
    [InlineData(14, "2023-06-15", "PMI")]
    public async Task Should_Return_Filtered_List_With_Any_Elements_From_Hotel_Search_Request(
        int noOfNights, string arrivalDate, string destinationAirport)
    {
        var hotelRequest = new HotelSearchRequest(noOfNights, arrivalDate, destinationAirport);
        var hotelDataLoader = new HotelDataLoader();
        var hotelData = await hotelDataLoader.GetData();
        
        Assert.True(hotelData.Count > 0);

        var hotelFilter = new HotelDataFilter(hotelRequest, hotelData);
        var results = hotelFilter.GetResults();

        Assert.True(results.Count > 0);
    }
}