using System;

public class PrimeFactors
{
    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        Console.Write("请输入一个正整数：");
        int number = int.Parse(Console.ReadLine());

        Console.Write(number + "的所有素数因子为：");
        for (int i = 2; i <= number; i++)
        {
            if (number % i == 0 && IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }

        Console.ReadLine();
    }
}
