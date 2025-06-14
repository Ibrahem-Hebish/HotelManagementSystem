namespace HotelSystem.CustomAttribute;

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
