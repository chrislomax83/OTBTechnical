using System.Text.Json;
using OTBTechnical.Data.Models;

namespace OTBTechnical.Data;

public class HotelDataLoader : AbstractDataLoader<HotelDataModel>
{
    private const string DefaultDataFileName = "./Data/DataFiles/HotelData.json";

    public HotelDataLoader()
    {
        SetFileName(DefaultDataFileName);
    }
    
    public override async Task<IReadOnlyList<HotelDataModel>> GetData()
    {
        await LoadData();

        return Data;
    }
}