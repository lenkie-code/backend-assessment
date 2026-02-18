namespace BackendAssessment.Domain.ValueObjects;

/// <summary>
/// Value object representing a monetary amount with a currency.
/// Immutable by design, following DDD value object principles.
/// </summary>
public record Money(decimal Amount, string Currency = "USD")
{
    public override string ToString() => $"{Currency} {Amount:N2}";
}
