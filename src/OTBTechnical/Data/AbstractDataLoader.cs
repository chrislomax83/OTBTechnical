using System.Text.Json;
using OTBTechnical.Data.Exceptions;
using OTBTechnical.Data.Models;

namespace OTBTechnical.Data;

public abstract class AbstractDataLoader<T> where T : IDataModel
{
    protected IReadOnlyList<T> Data = [];

    private string FileName { get; set; } = string.Empty;

    protected async Task LoadData()
    {
        if (string.IsNullOrEmpty(FileName))
            throw new DataFileNotFoundException("File name not set. Set in derived class or call SetFileName");
        
        if (!File.Exists(FileName)) throw new DataFileNotFoundException($"Data file {FileName} not found");
        
        using StreamReader fileReader = new(FileName);

        var fileContents = await fileReader.ReadToEndAsync();

        try
        {
            Data = JsonSerializer.Deserialize<IReadOnlyList<T>>(fileContents) ?? [];
        }
        catch (Exception ex)
        {
            throw new DataFileDeserializationException($"Data file {FileName} could not be deserialized", ex);
        }
    }

    public void SetFileName(string fileName)
    {
        FileName = fileName;
    }

    public abstract Task<IReadOnlyList<T>> GetData();
}