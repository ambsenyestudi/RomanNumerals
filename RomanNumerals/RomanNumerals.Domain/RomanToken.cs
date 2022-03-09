namespace RomanNumerals.Domain
{
    public class RomanToken
    {
        public static RomanToken I = new RomanToken(1, "I");
        private readonly string romanToken;
        public int Arabic { get; }

        public RomanToken(int arabic, string romanToken)
        {
            Arabic = arabic;
            this.romanToken = romanToken;
        }
        public override string ToString() => romanToken;

        public bool IsUnitPrepended(int evaluatingArabic) =>
            evaluatingArabic > 3 &&
            Arabic - evaluatingArabic == 1;

        public RomanToken[] PrependUnit() =>
            new RomanToken[] { I, this };

    }
}
