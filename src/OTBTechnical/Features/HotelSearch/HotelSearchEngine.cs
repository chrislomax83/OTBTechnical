using FluentValidation;
using OTBTechnical.Data;
using OTBTechnical.Data.Models;
using OTBTechnical.Features.HotelSearch.Models.Requests;
using OTBTechnical.Features.HotelSearch.Validators;

namespace OTBTechnical.Features.HotelSearch;

public class HotelSearchEngine
{
    private IReadOnlyList<HotelDataModel>? _data;
    
    public HotelSearchEngine() {}
    
    public HotelSearchEngine(IReadOnlyList<HotelDataModel> data)
    {
        _data = data;
    }

    private async Task LoadData()
    {
        var hotelDataLoader = new HotelDataLoader();

        _data = await hotelDataLoader.GetData();
    }
    
    public async Task<List<HotelDataModel>> Search(HotelSearchRequest request)
    {
        if (_data is null)
        {
            await LoadData();
        }

        var hotelRequestValidator = new HotelSearchRequestValidator();
        await hotelRequestValidator.ValidateAndThrowAsync(request);
        
        var hotelDataFilter = new HotelDataFilter(request, _data!);

        return hotelDataFilter.GetResults();
    }
}