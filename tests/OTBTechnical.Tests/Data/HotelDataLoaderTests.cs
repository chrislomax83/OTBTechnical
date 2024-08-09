using OTBTechnical.Data;

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
    
}