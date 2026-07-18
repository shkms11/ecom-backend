using System;
using System.Collections.Generic;
using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency = "BDT") // default to BDT
    {
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative", nameof(amount));
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency is required", nameof(currency));

        Amount = amount;
        Currency = currency.Trim().ToUpperInvariant(); // normalize currency code
    }

    // Addition
    public Money Add(Money other)
    {
        EnsureSameCurrency(other);
        return new Money(Amount + other.Amount, Currency);
    }

    // Subtraction
    public Money Subtract(Money other)
    {
        EnsureSameCurrency(other);
        if (Amount - other.Amount < 0)
            throw new InvalidOperationException("Resulting amount cannot be negative.");
        return new Money(Amount - other.Amount, Currency);
    }

    // Multiplication
    public Money Multiply(decimal factor)
    {
        if (factor < 0)
            throw new ArgumentException("Multiplier cannot be negative", nameof(factor));
        return new Money(Amount * factor, Currency);
    }

    // Division
    public Money Divide(decimal divisor)
    {
        if (divisor <= 0)
            throw new ArgumentException("Divisor must be positive", nameof(divisor));
        return new Money(Amount / divisor, Currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    private void EnsureSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException("Cannot operate on different currencies.");
    }

    public override string ToString() => $"{Currency} {Amount:N2}";

    public static Money Create(decimal amount, string currency = "BDT") =>
        new Money(amount, currency);
}
