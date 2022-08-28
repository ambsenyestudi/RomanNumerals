using RomanNumerals.Domain;

namespace RomanNumerals.Test;

public class RomanNumeralShould
{
    [Fact]
    public void Test1()
    {
        var romanNumeral = new RomanNumeral(1);
        Assert.Equal("I", romanNumeral.Value);
    }
}