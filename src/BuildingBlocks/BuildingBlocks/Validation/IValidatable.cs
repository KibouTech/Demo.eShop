namespace BuildingBlocks.Validation;


public interface IValidatable<T>
{
    static abstract (bool IsValid, string ErrorMessage) TryValidate(T value);
}
