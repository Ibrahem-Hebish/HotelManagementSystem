namespace HotelSystem.CustomAttribute;

public class GreaterThanZero : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var number = (int?)value;

        if (number is null || number <= 0)
            return false;

        return true;
    }

}

public class DecimalGreaterThanZero : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var number = (decimal?)value;

        if (number is null || number <= 0)
            return false;

        return true;
    }

}
