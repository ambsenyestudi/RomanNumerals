using RomanNumerals.Domain;
using System;
using Xunit;

namespace RomanNumerals.Test
{
    public class RomanNumeralsShould
    {
        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IIII")]
        public void Have_Units_When_UnderFive(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }
        [Theory]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(9, "VIIII")]
        public void Have_Five_Then_Units(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }
    }
}
