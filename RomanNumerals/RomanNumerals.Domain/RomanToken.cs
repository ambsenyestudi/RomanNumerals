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

    }
}
