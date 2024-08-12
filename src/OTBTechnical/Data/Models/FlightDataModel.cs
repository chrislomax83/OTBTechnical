using System.Text.Json.Serialization;

namespace OTBTechnical.Data.Models;

public record FlightDataModel(
    [property:JsonPropertyName(name:"id"), JsonRequired] int Id,
    [property:JsonPropertyName(name:"airline"), JsonRequired] string Airline,
    [property:JsonPropertyName(name:"from"), JsonRequired] string From,
    [property:JsonPropertyName(name:"to"), JsonRequired] string To,
    [property:JsonPropertyName(name:"price"), JsonRequired] decimal Price,
    [property:JsonPropertyName(name:"departure_date"), JsonRequired] DateOnly DepartureDate
): IDataModel;