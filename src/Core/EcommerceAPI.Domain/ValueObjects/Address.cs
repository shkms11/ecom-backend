using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string PostalCode { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string postalCode, string country)
    {
        // Validate required fields
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street is required", nameof(street));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required", nameof(city));
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State is required", nameof(state));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("PostalCode is required", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country is required", nameof(country));

        // Normalize values (trim spaces, uppercase postal code, standardize country)
        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        PostalCode = postalCode.Trim().ToUpperInvariant();
        Country = country.Trim().ToUpperInvariant();
    }

    // Equality comparison uses normalized values
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }

    // Optional: Factory method for creating from raw input
    public static Address Create(
        string street,
        string city,
        string state,
        string postalCode,
        string country
    ) => new Address(street, city, state, postalCode, country);

    // Optional: ToString for easier debugging/logging
    public override string ToString() => $"{Street}, {City}, {State}, {PostalCode}, {Country}";
}
