using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        private readonly RomanTokenSequence sequence;

        public int Arabic { get; }

        public RomanNumeral(int arabic)
        {
            var romanTokens = new RomanTokens();
            sequence = romanTokens.ToRomanTokenSequence(arabic);
            Arabic = arabic;
        }
        public override string ToString() =>
            sequence.ToString();
    }
}
