using RomanNumerals.Domain;

namespace RomanNumerals.Test;

public class RomanNumeralShould
{
    [Theory]
    [InlineData(1,"I")]
    public void Convert_When_Token(int arabic, string expected)
    {
        var romanNumeral = new RomanNumeral(arabic);
        Assert.Equal(expected, romanNumeral.Value);
    }
}