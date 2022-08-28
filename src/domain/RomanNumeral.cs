namespace RomanNumerals.Domain;
public record RomanNumeral
{
    public int Arabic { get; }
    public string Value { get; }
    public RomanNumeral(int arabic)
    {
        Arabic = arabic;
        if(!Enum.IsDefined(typeof(RomanToken), arabic))
        {
            throw new ArgumentException("Invalid arabic");
        }
        Value = ((RomanToken)arabic).ToString();
    }

}
