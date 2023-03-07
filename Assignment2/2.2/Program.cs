using System;

public class CalculateArray
{
    static void Main(string[] args)
    {
        Console.Write("请输入整数数组的大小：");
        int size = int.Parse(Console.ReadLine());

        int[] array = new int[size];  // 根据输入的大小定义整数数组

        Console.WriteLine("请逐个输入整数数组的元素：");
        for (int i = 0; i < size; i++)
        {
            Console.Write("数组元素" + (i + 1) + "：");
            array[i] = int.Parse(Console.ReadLine());
        }

        int max = array[0], min = array[0], sum = 0;
        double average = 0;

        // 遍历数组求最大值、最小值、总和
        foreach (int num in array)
        {
            if (num > max) max = num;
            if (num < min) min = num;
            sum += num;
        }

        // 求平均值
        average = (double)sum / array.Length;

        // 输出结果
        Console.WriteLine("数组的最大值为：" + max);
        Console.WriteLine("数组的最小值为：" + min);
        Console.WriteLine("数组的平均值为：" + average);
        Console.WriteLine("数组的所有元素之和为：" + sum);

        Console.ReadLine();
    }
}