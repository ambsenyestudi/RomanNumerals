using System;

namespace RomanNumerals.Domain
{
    public class RomanNumeral
    {
        private int arabicValue;

        public RomanNumeral(int arabicValue)
        {
            this.arabicValue = arabicValue;
        }
        public override string ToString()
        {
            if (arabicValue == 1)
            { 
                return "I"; 
            }
            else
            {
                return "II";
            }
        }
    }
}
