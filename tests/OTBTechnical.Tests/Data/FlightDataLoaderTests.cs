using OTBTechnical.Data;

namespace OTBTechnical.Tests.Data;

public class FlightDataLoaderTests
{
    [Fact]
    public async Task Should_Load_Flight_Data()
    {
        var dataLoader = new FlightDataLoader();
        
        var data = await dataLoader.GetData();
        
        Assert.True(data.Count > 0);
    }

    [Fact]
    public async Task Should_Validate_First_Record_In_Flight_Data()
    {
        var dataLoader = new FlightDataLoader();
        
        var data = await dataLoader.GetData();
        
        Assert.True(data.Count > 0);
        
        /*
           "id":1,
           "airline":"First Class Air",
           "from":"MAN",
           "to":"TFS",
           "price":470,
           "departure_date":"2023-07-01"
         */

        var firstRecord = data.OrderBy(e => e.Id).First();
        
        Assert.Equal(1, firstRecord.Id);
        Assert.Equal("First Class Air", firstRecord.Airline);
        Assert.Equal("MAN", firstRecord.From);
        Assert.Equal("TFS", firstRecord.To);
        Assert.Equal(470, firstRecord.Price);
        Assert.Equal(new DateOnly(2023, 07, 01), firstRecord.DepartureDate);
    }
}