using FluentValidation;
using OTBTechnical.Features.HotelSearch;
using OTBTechnical.Features.HotelSearch.Models.Requests;

namespace OTBTechnical.Tests.Features.HotelSearch;

public class HotelSearchEngineTests
{
    
    [Theory]
    [InlineData(7, "2022-11-05", "TFS", 2)]
    [InlineData(14, "2023-06-15", "PMI", 2)]
    [InlineData(14, "2022-11-10", "LPA", 1)]
    public async Task Should_Return_All_Hotels_For_Search_Term(
        int noOfNights, string arrivalDate, string destinationAirport, int expectedElements)
    {
        var hotelRequest = new HotelSearchRequest(noOfNights, arrivalDate, destinationAirport);

        var searchEngine = new HotelSearchEngine();
        
        var searchResults = await searchEngine.Search(hotelRequest);
        
        Assert.Equal(expectedElements, searchResults.Count);
    }
    
    [Theory]
    [InlineData(0, "2024-11-05", "TFS")]
    [InlineData(6, "2024-13-15", "PMI")]
    [InlineData(3, "2024-11-10", "LPA3")]
    public async Task Should_Throw_ValidationException_For_Invalid_Search_Term_Arguments(
        int noOfNights, string arrivalDate, string destinationAirport)
    {
        var hotelRequest = new HotelSearchRequest(noOfNights, arrivalDate, destinationAirport);

        var searchEngine = new HotelSearchEngine();
        
        await Assert.ThrowsAsync<ValidationException>(() => searchEngine.Search(hotelRequest));
    }
    
}