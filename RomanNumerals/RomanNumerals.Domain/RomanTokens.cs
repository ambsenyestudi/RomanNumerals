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
                var romanTokenSequence = FigureTokenSequence(evaluationgArabic);
                result.AddRange(romanTokenSequence);
                evaluationgArabic -= RomanToken.ToArabic(romanTokenSequence);
            }
            return result;
        }

        private RomanToken[] FigureTokenSequence(int evaluatingArabic)
        {

            var unitPrependableToken = tokenList.FirstOrDefault(x => x.CanPrependUnit(evaluatingArabic));
            if (unitPrependableToken != null)
            {
                return new RomanToken[] { RomanToken.I, unitPrependableToken };
            }
            var romanToken = tokenList.First(x => x.Arabic <= evaluatingArabic);
            return new RomanToken[] { romanToken };
        }

    }
}
