using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        GetMaxNumber();
    }

    public static void GetMaxNumber()
    {
        double maxNumber = double.MinValue;
        int maxNumberStart = 0;
        int maxNumberSteps = 0;

        for (int i = 1; i < int.MaxValue; i++)
        {
            double number = i;
            List<double> values = GetNewValues(number, 1000);

            foreach (double value in values)
            {
                if (value > maxNumber)
                {
                    maxNumber = value;
                    maxNumberStart = i;
                    maxNumberSteps = values.IndexOf(value);
                }
            }

            if (i % 10000 == 0)
            {
                Console.WriteLine($"Processed {i} numbers. Max number: {maxNumber} (Start: {maxNumberStart}, Steps: {maxNumberSteps})");
            }
        }

        Console.WriteLine($"Final Max Number: {maxNumber} (Start: {maxNumberStart}, Steps: {maxNumberSteps})");
    }

    private static List<double> GetNewValues(double number, int maxSteps)
    {
        var values = new List<double>();

        for (int i = 0; i < maxSteps; i++)
        {
            // 3x + 1 problem
            number = number % 2 != 0 ? number * 3 + 1 : number / 2;

            values.Add(number);
        }

        return values;
    }
}