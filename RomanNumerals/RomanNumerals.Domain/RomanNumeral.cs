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
            if(IsMinusOnePer(evaluatingArabic))
            {
                if (arabicValue == 4)
                {
                    return (4, "IV");
                }
                if (arabicValue == 9)
                {
                    return (9, "IX");
                }
            }
            var arabicNumeral = romanTokensDictionary.Keys.First(x => x <= evaluatingArabic);
            return (arabicNumeral, romanTokensDictionary[arabicNumeral]);
        }

        private bool IsMinusOnePer(int evaluatingArabic) => 
            evaluatingArabic == 4 || evaluatingArabic == 9;
    }
}
