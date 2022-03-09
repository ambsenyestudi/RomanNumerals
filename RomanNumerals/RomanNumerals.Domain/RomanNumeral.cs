using System;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        const string UNIT_TOKEN = "I";
        const string FIVE_TOKEN = "V";
        private int arabicValue;

        public RomanNumeral(int arabicValue)
        {
            this.arabicValue = arabicValue;
        }
        public override string ToString()
        {
            if(arabicValue == 4)
            {
                return "IV";
            }
            if(arabicValue == 9)
            {
                return "IX";
            }
            var result = string.Empty;
            
            var evaluationgArabic = arabicValue;
            if (evaluationgArabic >= 5)
            {
                result = FIVE_TOKEN;
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
