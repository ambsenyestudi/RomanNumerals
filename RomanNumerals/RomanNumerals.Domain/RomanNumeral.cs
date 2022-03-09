using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        private Dictionary<int, string> romanTokensDictionary = new Dictionary<int, string>
        {
            [10] = "X",
            [5] = "V",
            [1] = "I"
        };
        private int arabicValue;

        public RomanNumeral(int arabicValue)
        {
            this.arabicValue = arabicValue;
        }
        public override string ToString() => 
            FigureRomanTokens();

        private string FigureRomanTokens()
        {
            var result = string.Empty;

            var evaluationgArabic = arabicValue;
            while (evaluationgArabic > 0)
            {
                var (arabicNumeral, romanToken) = FigureToken(evaluationgArabic);
                result += romanToken;
                evaluationgArabic -= arabicNumeral;
            }
            return result;
        }

        private (int, string) FigureToken(int evaluatingArabic)
        {
            var result = string.Empty;
            if(IsMinusOnePer(evaluatingArabic))
            {
                result = romanTokensDictionary.Values.Last();
                var plusOneArabic = romanTokensDictionary.Keys.First(x => x <= evaluatingArabic + 1);
                result += romanTokensDictionary[plusOneArabic];
                return (plusOneArabic - 1, result);
            }
            var arabicNumeral = romanTokensDictionary.Keys.First(x => x <= evaluatingArabic);
            result += romanTokensDictionary[arabicNumeral];
            return (arabicNumeral, result);
        }

        private bool IsMinusOnePer(int evaluatingArabic) => 
            evaluatingArabic > 3 &&
            romanTokensDictionary.Keys.Any(x => x == evaluatingArabic + 1);
            
    }
}
