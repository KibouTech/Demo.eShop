using FluentValidation;

namespace BuildingBlocks.Validation;

public static class FluentValidationExtensions
{

    //RuleFor(x => x.Email)
    //    .MustBeValid<CreateCustomerCommand, EmailAddress>();
    public static IRuleBuilderOptionsConditions<T, string> MustBeValid<T, TValueObject>(
        this IRuleBuilder<T, string> ruleBuilder)
        where TValueObject : IValidatable<string>
    {
        return ruleBuilder.Custom((value, context) => {
            var (isValid, errorMessage) = TValueObject.TryValidate(value);
            if (!isValid)
            {
                context.AddFailure(errorMessage);
            }
        });
    }
}