using System.Text.Json;
using OTBTechnical.Data.Models;

namespace OTBTechnical.Data;

public class HotelDataLoader
{
    private const string FileName = "./Data/DataFiles/HotelData.json";
    private IReadOnlyList<HotelDataModel> _data = [];
    
    private async Task LoadData()
    {
        using StreamReader fileReader = new(FileName);

        var fileContents = await fileReader.ReadToEndAsync();

        _data = JsonSerializer.Deserialize<IReadOnlyList<HotelDataModel>>(fileContents) ?? [];
    }
    
    public async Task<IReadOnlyList<HotelDataModel>> GetData()
    {
        await LoadData();

        return _data;
    }
}