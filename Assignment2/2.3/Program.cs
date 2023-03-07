using System;

public class SieveOfEratosthenes
{
    static void Main(string[] args)
    {
        int n = 100;
        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        Console.Write("2~100以内的素数有：");
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }

        Console.ReadLine();
    }
}