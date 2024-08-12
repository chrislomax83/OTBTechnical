using OTBTechnical.Data;
using OTBTechnical.Data.Exceptions;

namespace OTBTechnical.Tests.Data;

public class HotelDataLoaderTests
{
    
    [Fact]
    public async Task Should_Load_Hotel_Data()
    {
        var dataLoader = new HotelDataLoader();

        var data = await dataLoader.GetData();
        
        Assert.True(data.Count > 0);
    }
    
    [Fact]
    public async Task Should_Validate_First_Record_In_Hotel_Data()
    {
        var dataLoader = new HotelDataLoader();
        
        var data = await dataLoader.GetData();
        
        Assert.True(data.Count > 0);
        
        /*
           "id": 1,
           "name": "Iberostar Grand Portals Nous",
           "arrival_date": "2022-11-05",
           "price_per_night": 100,
           "local_airports": ["TFS"],
           "nights": 7
         */

        var firstRecord = data.OrderBy(e => e.Id).First();

        var expectedLocalAirports = new string[] { "TFS" };
        
        Assert.Equal(1, firstRecord.Id);
        Assert.Equal("Iberostar Grand Portals Nous", firstRecord.Name);
        Assert.Equal(expectedLocalAirports, firstRecord.LocalAirports);
        Assert.Equal(7, firstRecord.Nights);
        Assert.Equal(100, firstRecord.PricePerNight);
        Assert.Equal(new DateOnly(2022, 11, 05), firstRecord.ArrivalDate);
    }
    
    [Fact]
    public async Task Should_Throw_DataFileDeserializationException_With_Missing_ArrivalDate_In_Invalid_Hotel_Data()
    {
        var dataLoader = new HotelDataLoader();
        var invalidJsonFile = "./Data/DataFiles/InvalidHotelData.json";
        
        // Set the filename to invalid json
        dataLoader.SetFileName(invalidJsonFile);

        await Assert.ThrowsAsync<DataFileDeserializationException>(() => dataLoader.GetData());
    }
    
}