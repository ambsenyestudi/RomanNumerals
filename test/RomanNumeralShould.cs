using RomanNumerals.Domain;

namespace RomanNumerals.Test;

public class RomanNumeralShould
{
    [Theory]
    [InlineData(1,"I")]
    [InlineData(5, "V")]
    [InlineData(10, "X")]
    [InlineData(50, "L")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    public void Convert_When_Token(int arabic, string expected)
    {
        var romanNumeral = new RomanNumeral(arabic);
        Assert.Equal(expected, romanNumeral.Value);
    }
}