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
        
        public RomanTokenSequence ToRomanTokenSequence(int arabic)
        {
            return FigureRomanTokenSequence(arabic);
        }
        
        private RomanTokenSequence FigureRomanTokenSequence(int arabic)
        {
            var resultingSequence = new RomanTokenSequence();
            var evaluationgArabic = arabic;
            while (evaluationgArabic > 0)
            {
                var currentSequence = FigureTokenSequence(evaluationgArabic);
                resultingSequence = resultingSequence.Add(currentSequence);
                evaluationgArabic -= currentSequence.ToArabic();
            }
            return resultingSequence;
        }

        private RomanTokenSequence FigureTokenSequence(int evaluatingArabic)
        {

            var unitPrependableToken = tokenList.FirstOrDefault(x => x.CanPrependUnit(evaluatingArabic));
            if (unitPrependableToken != null)
            {
                return new RomanTokenSequence(RomanToken.I, unitPrependableToken );
            }
            var romanToken = tokenList.First(x => x.Arabic <= evaluatingArabic);
            return new RomanTokenSequence(romanToken);
        }

    }
}
