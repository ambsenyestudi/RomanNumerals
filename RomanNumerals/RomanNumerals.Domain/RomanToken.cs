using System.Collections.Generic;

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
            for (int i = 0; i < tokenSequence.Length; i++)
            {
                int arabic = tokenSequence[i].Arabic;
                if(!IsLast(i, tokenSequence.Length) && TrySubstractArabic(tokenSequence[i], tokenSequence[i+1], out arabic))
                {
                    i++;
                    result += tokenSequence[i].Arabic;
                }
                result += arabic;
            }
            return result;
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

        private static bool IsSmallerThanNext(int index, RomanToken[] tokenSequence)
        {
            if(IsLast(index,tokenSequence.Length))
            {
                return false;
            }
            return tokenSequence[index].Arabic < tokenSequence[index + 1].Arabic;
        }

        private static bool IsLast(int index, int length) =>
            length - index == 1;
    }
}
