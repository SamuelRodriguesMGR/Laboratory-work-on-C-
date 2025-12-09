using System.Collections.Generic;
using System.Net;


public class RightTriangle
{
    private double FirstSide;
    private double SecondSide;

    public RightTriangle(double a, double b)
    {
        FirstSide = a;
        SecondSide = b;

        if (FirstSide <= 0 || SecondSide <= 0)
        {
            throw new Exception("Одна из сторон меньше или равна 0");
        } 
    }
    
    private double GetSquare()
    {
        return FirstSide * SecondSide * 0.5;
    }

    public override string ToString()
    {
        return $"RightTriangle: a = {FirstSide}, b = {SecondSide}, Area = {GetSquare()}";
    }

    
}