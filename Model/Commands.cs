namespace ParseDontValidate.Model;

/*
    The model defines the possible outcomes of parsing, validating and transforming the input data.

    It should not be possible to represent invalid state. This means:
    - Each type should have exactly and only the relevant fields.
    - It should be impossible to instantiate any of these types with values that are not permissible.

    The result of parsing bad data is not necessarily an exception. This can be represented as an outcome,
    in this case Invalid.
*/

// This empty interface is used to unify all commands under one "type", even if they have no fields in common.
public interface ICommand { }

public record TrimMessage : ICommand
{
    // The constructor ensures that invalid values cannot be instantiated
    public TrimMessage(string message, int maxLength)
    {
        if (maxLength < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength), "MaxLength must be at least 1.");
        }

        Message = message;
        MaxLength = maxLength;
    }

    public string Message { get; init; }
    public int MaxLength { get; init; }
}

public record GetCurrentTime : ICommand { }

public record GenerateRandomNumber : ICommand
{
    // The constructor ensures that invalid values cannot be instantiated
    public GenerateRandomNumber(int min, int max)
    {
        if (min < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(min), "Min may not be less than 0.");
        }

        if (max < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(max), "Max may not be less than 1.");
        }

        if (min >= max)
        {
            throw new ArgumentOutOfRangeException(nameof(min), "Min must be smaller than Max.");
        }

        Min = min;
        Max = max;
    }

    public int Min { get; init; }
    public int Max { get; init; }
}

public record Invalid : ICommand { }