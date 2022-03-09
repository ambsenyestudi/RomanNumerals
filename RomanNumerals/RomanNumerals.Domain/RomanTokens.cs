using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanTokens
    {
        private readonly List<RomanToken> tokenList;

        public RomanTokens()
        {
            tokenList = new List<RomanToken> 
            { 
                RomanToken.X,
                RomanToken.V,
                RomanToken.I 
            };
        }
        public List<RomanToken> ToRomanTokenList(int arabic)
        {
            return FigureRomanTokens(arabic);
        }
        private List<RomanToken> FigureRomanTokens(int arabic)
        {
            var result = new List<RomanToken>();

            var evaluationgArabic = arabic;
            while (evaluationgArabic > 0)
            {
                var (arabicNumeral, romanTokens) = FigureToken(evaluationgArabic);
                result.AddRange(romanTokens);
                evaluationgArabic -= arabicNumeral;
            }
            return result;
        }

        private (int, RomanToken[]) FigureToken(int evaluatingArabic)
        {

            var unitPrependableToken = tokenList.FirstOrDefault(x => x.CanPrependUnit(evaluatingArabic));
            if (unitPrependableToken != null)
            {
                var result = new RomanToken[] { RomanToken.I, unitPrependableToken };
                return (result.Last().Arabic - result.First().Arabic, result);
            }
            var romanToken = tokenList.First(x => x.Arabic <= evaluatingArabic);
            return (romanToken.Arabic, new RomanToken[] { romanToken });
        }

    }
}
