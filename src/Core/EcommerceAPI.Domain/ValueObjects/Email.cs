using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private static readonly Regex EmailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase
    );

    public string Value { get; }

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required", nameof(email));

        // Normalize: trim spaces and convert to lowercase
        var normalizedEmail = email.Trim().ToLowerInvariant();

        // Validate format
        if (!EmailRegex.IsMatch(normalizedEmail))
            throw new ArgumentException("Email is invalid", nameof(email));

        Value = normalizedEmail;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    // Optional factory method for readability
    public static Email Create(string email) => new Email(email);

    // Optional: for logging/debugging
    public override string ToString() => Value;
}
