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
            if (arabicValue == 4)
            {
                return "IV";
            }
            if (arabicValue == 9)
            {
                return "IX";
            }
            
            return FigureBiggerPrepended();
        }

        private string FigureBiggerPrepended()
        {
            var result = string.Empty;
            
            var evaluationgArabic = arabicValue;
            while(evaluationgArabic > 0)
            {
                var (arabicNumeral, romanToken) = FigureToken(evaluationgArabic);
                result += romanToken;
                evaluationgArabic -= arabicNumeral;
            }
            return result;
        }

        private (int, string) FigureToken(int evaluationgArabic)
        {
            var arabicNumeral = romanTokensDictionary.Keys.First(x => x <= evaluationgArabic);
            return (arabicNumeral, romanTokensDictionary[arabicNumeral]);
        }
    }
}
