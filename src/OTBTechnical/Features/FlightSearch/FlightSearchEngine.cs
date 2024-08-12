using OTBTechnical.Data;
using OTBTechnical.Data.Models;
using OTBTechnical.Features.FlightSearch.Models.Requests;

namespace OTBTechnical.Features.FlightSearch;

public class FlightSearchEngine
{

    private IReadOnlyList<FlightDataModel>? _data;
    
    public FlightSearchEngine() {}
    
    public FlightSearchEngine(IReadOnlyList<FlightDataModel> data)
    {
        _data = data;
    }

    private async Task LoadData()
    {
        var flightDataLoader = new FlightDataLoader();

        _data = await flightDataLoader.GetData();
    }
    
    public async Task<List<FlightDataModel>> Search(FlightSearchRequest request)
    {
        if (_data is null)
        {
            await LoadData();
        }
        

        var flightDataFilter = new FlightDataFilter(request, _data!);

        return flightDataFilter.GetResults();
    }
    
}