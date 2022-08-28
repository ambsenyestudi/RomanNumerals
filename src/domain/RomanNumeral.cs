﻿namespace RomanNumerals.Domain;
public record RomanNumeral
{
    public int Arabic { get; }
    public string Value { get; }
    public RomanNumeral(int arabic)
    {
        Arabic = arabic;
        if(Enum.IsDefined(typeof(RomanToken), arabic))
        {
            Value = ((RomanToken)arabic).ToString();
        }
    }

}
