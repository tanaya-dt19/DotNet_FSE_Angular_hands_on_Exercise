using System;

class Program
{
    //Recursive Method
    static double PredictFutureValue(double currentVal, double growthRate, int years)
    {
        if(years == 0)
        {
            return currentVal;
        }

        //Recursive Call
        return PredictFutureValue(currentVal * (1 + growthRate), growthRate, years - 1);
    }

    static void Main(string[] args)
    {
        double currentVal = 10000;
        double growthRate = 0.10; // 10%
        int years = 3;

        double futureValue = PredictFutureValue(currentVal, growthRate, years);

        Console.WriteLine("Future Value : " + futureValue);

        Console.ReadKey();
    }
}