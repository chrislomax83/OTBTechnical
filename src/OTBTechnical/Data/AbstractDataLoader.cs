using System.Text.Json;
using OTBTechnical.Data.Models;

namespace OTBTechnical.Data;

public abstract class AbstractDataLoader<T> where T : IDataModel
{
    protected IReadOnlyList<T> Data = [];

    private string FileName { get; set; } = string.Empty;

    protected async Task LoadData()
    {
        using StreamReader fileReader = new(FileName);

        var fileContents = await fileReader.ReadToEndAsync();

        Data = JsonSerializer.Deserialize<IReadOnlyList<T>>(fileContents) ?? [];
    }

    public void SetFileName(string fileName)
    {
        FileName = fileName;
    }

    public abstract Task<IReadOnlyList<T>> GetData();
}