using System;
using ManagedCuda;
using ManagedCuda.BasicTypes;

public class Program
{
    static async Task Main(string[] args)
    {
        await GetNumAsync();
    }

    public static async Task GetNumAsync()
    {
        double maxNumber = double.MinValue;

        for (int i = 0; i < int.MaxValue; i++)
        {
            double number = i;

            var values = await GetNewValuesAsync(number, 1000);

            foreach (double value in values)
            {
                if (value > maxNumber)
                {
                    maxNumber = value;
                    Console.WriteLine($"Number: {number} -- {maxNumber}");
                }
            }
        }
    }

    private static List<double> GetNewValues(double number, int maxSteps)
    {
        var values = new List<double>();

        using (CudaContext context = new CudaContext())
        {
            double[] hostValues = new double[maxSteps];
            CudaDeviceVariable<double> deviceValues = new CudaDeviceVariable<double>(maxSteps);

            for (int i = 0; i < maxSteps; i++)
            {
                // 3x + 1 problem
                number = number % 2 != 0 ? number * 3 + 1 : number / 2;
                hostValues[i] = number;
            }

            deviceValues.CopyToDevice(hostValues);

            deviceValues.CopyToHost(hostValues);

            values.AddRange(hostValues);
        }

        return values;
    }

    private static async Task<List<double>> GetNewValuesAsync(double number, int maxSteps)
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