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
            
            var unitPrependableToken = romanTokenList.FirstOrDefault(x => x.IsUnitPrepended(evaluatingArabic));
            if(unitPrependableToken != null)
            {
                var prependeList = unitPrependableToken.PrependUnit().Select(x=>x.ToString());
                var result = string.Join("", prependeList);
                return (unitPrependableToken.Arabic - 1, result);
            }
            var romanToken = romanTokenList.First(x => x.Arabic <= evaluatingArabic);
            return (romanToken.Arabic, romanToken.ToString());
        }
                    
    }
}
