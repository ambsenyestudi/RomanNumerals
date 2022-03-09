namespace RomanNumerals.Domain
{
    public class RomanToken
    {
        private readonly string romanToken;
        public int Arabic { get; }

        public RomanToken(int arabic, string romanToken)
        {
            Arabic = arabic;
            this.romanToken = romanToken;
        }
        public override string ToString() => romanToken;

    }
}
