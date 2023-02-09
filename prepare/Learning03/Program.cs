using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetTop());
        fraction.SetTop(5);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        fraction.Set(3, 4);
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        fraction.SetBottom(2);
        Console.WriteLine(fraction.GetBottom());
    }
}

class Fraction{
    private int top;
    private int bottom;

    public Fraction(){
        top = 1;
        bottom = 1;
    }

    public Fraction(int _top, int _bottom){
        top = _top;
        bottom = _bottom;
    }

    public int GetTop(){
        return top;
    }

    public void SetTop(int _top){
        top = _top;
    }

    public int GetBottom(){
        return bottom;
    }

    public void SetBottom(int _bottom){
        bottom = _bottom;
    }

    public void Set(int _top, int _bottom){
        top = _top;
        bottom = _bottom;
    }

    public string GetFractionString(){
        return "" + top + "/" + bottom;
    }

    public double GetDecimalValue(){
        return (double) top / bottom;
    }
}