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
            var result = string.Empty;
            var evaluationgArabic = arabicValue;
            if (evaluationgArabic >= 5)
            {
                result = "V";
                evaluationgArabic -= 5;
            }
            
            for (int i = 0; i < evaluationgArabic; i++)
            {
                result += UNIT_TOKEN;
            }
            return result;
        }
    }
}
