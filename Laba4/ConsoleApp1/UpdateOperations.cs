using System.Collections.Generic;
using System.Net;


public class RightTriangle
{
    private double FirstSide;
    private double SecondSide;

    public RightTriangle(double a, double b)
    {
        if (a <= 0 || b <= 0)
        {
            throw new Exception("Одна из сторон меньше или равна 0");
        } 
        FirstSide = a;
        SecondSide = b;

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

public class RightTriangle2
{
    private double FirstSide;
    private double SecondSide;

    public RightTriangle2(double a, double b)
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

    public static RightTriangle2 operator ++(RightTriangle2 triangle)
    {
        return new RightTriangle2(triangle.FirstSide * 2, triangle.SecondSide * 2);
    }

    public static RightTriangle2 operator --(RightTriangle2 triangle)
    {
        return new RightTriangle2(triangle.FirstSide / 2, triangle.SecondSide / 2);
    }
    

    public override string ToString()
    {
        return $"RightTriangle: a = {FirstSide}, b = {SecondSide}, Area = {GetSquare()}";
    }

}