namespace OTBTechnical.Validators;

public static class DateValidators
{
    public static bool BeAValidDateOnly(string departureDate)
    {
        return DateOnly.TryParse(departureDate, out _);
    }
}