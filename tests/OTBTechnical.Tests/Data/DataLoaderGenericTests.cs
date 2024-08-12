using OTBTechnical.Data;
using OTBTechnical.Data.Exceptions;

namespace OTBTechnical.Tests.Data;

public class DataLoaderGenericTests
{
    [Fact]
    public async Task Should_Throw_DataFileNotFoundException_With_Invalid_File()
    {
        var dataLoader = new FlightDataLoader();
        var dummyDataFile = "./null.json";
        
        // Set the filename to something irrelevant
        dataLoader.SetFileName(dummyDataFile);

        var result = await Assert.ThrowsAsync<DataFileNotFoundException>(() => dataLoader.GetData());
        Assert.Equal($"Data file {dummyDataFile} not found", result.Message);
    }
    
    [Fact]
    public async Task Should_Throw_DataFileNotFoundException_With_Empty_File_Path()
    {
        var dataLoader = new FlightDataLoader();
        var dummyDataFile = "";
        
        // Set the filename to an empty string
        dataLoader.SetFileName(dummyDataFile);

        var result = await Assert.ThrowsAsync<DataFileNotFoundException>(() => dataLoader.GetData());
        Assert.Equal($"File name not set. Set in derived class or call SetFileName", result.Message);
    }
    
    [Fact]
    public async Task Should_Throw_DataFileDeserializationException_With_Invalid_Json_File()
    {
        var dataLoader = new FlightDataLoader();
        var invalidJsonFile = "./Data/DataFiles/InvalidJsonData.json";
        
        // Set the filename to invalid json
        dataLoader.SetFileName(invalidJsonFile);

        await Assert.ThrowsAsync<DataFileDeserializationException>(() => dataLoader.GetData());
    }
}