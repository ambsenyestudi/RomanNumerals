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
        public void Have_Units_When_Under_Four(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }
        
        [Theory]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        public void Have_Five_Then_Under_Nine(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(9, "IX")]
        public void Have_Prepended_Unit_When__Four_Or_Nine(int arabic, string expected)
        {
            var sut = new RomanNumeral(arabic);
            Assert.Equal(expected, sut.ToString());
        }
    }
}
