using System.Text.RegularExpressions;
using BuildingBlocks.Validation;

namespace Ordering.Domain.ValueObjects;

public readonly record struct EmailAddress : IValidatable<string>
{
    public string Value { get; }

    public EmailAddress(string value) => Value = value;

    public static EmailAddress Of(string value)
    {
        var (isValid, error) = TryValidate(value);
        if (!isValid)
            throw new ArgumentException(error);

        return new EmailAddress(value);
    }

    public static (bool IsValid, string ErrorMessage) TryValidate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return (false, "Email cannot be empty.");

        if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return (false, "Invalid email format.");

        return (true, string.Empty);

    }

    public override string ToString() => Value;
}