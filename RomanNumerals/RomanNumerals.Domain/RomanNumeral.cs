using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        private List<RomanToken> romanTokenList = new List<RomanToken>();

        public int Arabic { get; }

        public RomanNumeral(int arabic)
        {
            var romanTokens = new RomanTokens();
            romanTokenList = romanTokens.ToRomanTokenList(arabic);
            Arabic = arabic;
        }
        public override string ToString()
        {
            var romantTokenValues = romanTokenList.Select(x => x.ToString());
            return string.Join("", romantTokenValues);
        }        
    }
}
