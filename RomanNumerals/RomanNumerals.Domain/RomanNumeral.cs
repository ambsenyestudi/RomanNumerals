using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        private List<RomanToken> romanTokenList = new List<RomanToken>()
        {
            new RomanToken(10, "X"),
            new RomanToken(5, "V"),
            new RomanToken(1, "I")
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
                result = romanTokenList.Last().ToString();
                var plusOneRomanToken = romanTokenList.First(x => x.Arabic == evaluatingArabic + 1);
                result += plusOneRomanToken.ToString();
                return (plusOneRomanToken.Arabic - 1, result);
            }
            var romanToken = romanTokenList.First(x => x.Arabic <= evaluatingArabic);
            result += romanToken.ToString();
            return (romanToken.Arabic, result);
        }

        private bool IsMinusOnePer(int evaluatingArabic) => 
            evaluatingArabic > 3 &&
            romanTokenList.Any(x => x.Arabic == evaluatingArabic + 1);
            
    }
}
