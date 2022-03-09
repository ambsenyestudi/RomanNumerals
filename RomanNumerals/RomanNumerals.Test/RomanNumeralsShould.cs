using RomanNumerals.Domain;
using System;
using Xunit;

namespace RomanNumerals.Test
{
    public class RomanNumeralsShould
    {
        [Fact]
        public void HaveUnits()
        {
            var exptected = "I";
            var sut = new RomanNumeral(1);
            Assert.Equal(exptected, sut.ToString());
        }
    }
}
