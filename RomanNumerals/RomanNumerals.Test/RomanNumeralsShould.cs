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
        public void HaveUnits(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }
    }
}
