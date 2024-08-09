using System.Text.Json.Serialization;

namespace OTBTechnical.Data.Models;

public record HotelDataModel(
    [property: JsonPropertyName(name: "id"), JsonRequired]
    int Id,
    [property: JsonPropertyName(name: "name"), JsonRequired]
    string Name,
    [property: JsonPropertyName(name: "arrival_date"), JsonRequired]
    DateOnly ArrivalDate,
    [property: JsonPropertyName(name: "price_per_night"), JsonRequired]
    int PricePerNight,
    [property: JsonPropertyName(name: "local_airports"), JsonRequired]
    string[] LocalAirports,
    [property: JsonPropertyName(name: "nights"), JsonRequired]
    int Nights
):IDataModel
{
    public decimal TotalCost => PricePerNight * Nights;
};