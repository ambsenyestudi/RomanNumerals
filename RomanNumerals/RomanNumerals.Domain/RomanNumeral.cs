using System;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        const string UNIT_TOKEN = "I";
        private int arabicValue;

        public RomanNumeral(int arabicValue)
        {
            this.arabicValue = arabicValue;
        }
        public override string ToString()
        {
            if(arabicValue == 5)
            {
                return "V";
            }
            var result = string.Empty;
            for (int i = 0; i < arabicValue; i++)
            {
                result += UNIT_TOKEN;
            }
            return result;
        }
    }
}
