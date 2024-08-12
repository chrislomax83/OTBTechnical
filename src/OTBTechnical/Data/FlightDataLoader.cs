using OTBTechnical.Data.Models;

namespace OTBTechnical.Data;

public class FlightDataLoader: AbstractDataLoader<FlightDataModel>
{
    private const string DefaultDataFileName = "./Data/DataFiles/FlightData.json";

    public FlightDataLoader()
    {
        SetFileName(DefaultDataFileName);
    }
    
    public override async Task<IReadOnlyList<FlightDataModel>> GetData()
    {
        await LoadData();

        return Data;
    }
}