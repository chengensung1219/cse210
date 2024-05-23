using System;

public class Fraction
{
    private int top;
    private int bottom;

    public Fraction()
    {
        top = 1;
        bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        top = wholeNumber;
        bottom = 1;
    }

    public Fraction(int number1, int number2)
    {
        top = number1;
        bottom = number2;
    }

    public string GetFractionString()
    {
        string text = $"{top}/{bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        double result = (double)top / (double)bottom;
        return result;
    }
}