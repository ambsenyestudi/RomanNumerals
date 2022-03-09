using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanTokenSequence
    {
        private readonly RomanToken[] romanTokens;

        public RomanTokenSequence(params RomanToken[] romanTokens)
        {
            this.romanTokens = romanTokens == null 
                ? new RomanToken[0]
                : romanTokens;
        }
        public RomanTokenSequence Add(RomanTokenSequence other) =>
            new RomanTokenSequence(
                romanTokens.Concat(other.romanTokens).ToArray());

        public override string ToString() =>
            string.Join("", romanTokens.Select(x => x.ToString()));

        public int ToArabic()
        {
            var result = 0;
            var tokenList = romanTokens.ToList();
            while (tokenList.Any())
            {
                var arabic = tokenList.First().Arabic;
                if (tokenList.Count > 1 && TrySubstractArabic(tokenList.Take(2), out arabic))
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
            if (tokens.Count() > 2)
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
