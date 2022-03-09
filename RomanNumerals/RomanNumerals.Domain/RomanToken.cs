using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanToken
    {
        public static RomanToken I = new RomanToken(1, "I");
        public static RomanToken V = new RomanToken(5, "V");
        public static RomanToken X = new RomanToken(10, "X");
        private readonly string romanToken;
        public int Arabic { get; }

        private RomanToken(int arabic, string romanToken)
        {
            Arabic = arabic;
            this.romanToken = romanToken;
        }
        public override string ToString() => romanToken;

        public bool CanPrependUnit(int evaluatingArabic) =>
            Arabic - evaluatingArabic == I.Arabic;

        public static int ToArabic(RomanToken[] tokenSequence)
        {
            var result = 0;
            var tokenList = tokenSequence.ToList();
            while(tokenList.Any())
            {
                var arabic = tokenList.First().Arabic;
                if(tokenList.Count > 1 && TrySubstractArabic(tokenList.Take(2), out arabic))
                {
                    tokenList.RemoveAt(0);                    
                }
                tokenList.RemoveAt(0);
                result += arabic;
            }
            return result;
        }
        private static bool TrySubstractArabic(IEnumerable<RomanToken> tokens, out int result)
        {
            if(tokens.Count()>2)
            {
                result = 0;
                return false;
            }
            return TrySubstractArabic(tokens.First(), tokens.Skip(1).Single(), out result);
        }
        private static bool TrySubstractArabic(RomanToken smaller, RomanToken bigger, out int result)
        {
            if (smaller.Arabic < bigger.Arabic)
            {
                result = bigger.Arabic - smaller.Arabic;
                return true;
            }
            result = 0;
            return false;
        }

    }
}
