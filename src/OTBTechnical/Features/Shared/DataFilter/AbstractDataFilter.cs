using OTBTechnical.Data.Models;
using OTBTechnical.Features.Shared.Search;

namespace OTBTechnical.Features.Shared.DataFilter;

public abstract class AbstractDataFilter<TSearchRequest, TDataModel>(
    TSearchRequest request,
    IReadOnlyList<TDataModel> data)
    where TSearchRequest : ISearchRequest
    where TDataModel : IDataModel
{
    protected IQueryable<TDataModel> FilteredData = data.AsQueryable();
    protected readonly TSearchRequest Request = request;

    protected abstract void ApplyFilters();

    public List<TDataModel> GetResults()
    {
        ApplyFilters();

        return FilteredData.ToList();
    }
}