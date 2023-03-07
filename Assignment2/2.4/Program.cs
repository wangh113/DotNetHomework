using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("请输入矩阵的行数：");
        int m = int.Parse(Console.ReadLine());
        Console.Write("请输入矩阵的列数：");
        int n = int.Parse(Console.ReadLine());

        // 初始化矩阵
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++)
        {
            matrix[i] = new int[n];
            Console.Write($"请输入第{i + 1}行的数据，各元素用空格隔开：");
            string[] s = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i][j] = int.Parse(s[j]);
            }
        }

        bool isToeplitz = IsToeplitzMatrix(matrix);
        Console.WriteLine(isToeplitz ? "是托普利茨矩阵" : "不是托普利茨矩阵");
        Console.ReadKey();
    }

    static bool IsToeplitzMatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int diff = i - j;
                if (!dict.ContainsKey(diff))
                {
                    dict.Add(diff, matrix[i][j]); // 将第 diff 条对角线上元素存入字典
                }
                else if (dict[diff] != matrix[i][j])
                {
                    return false; // 对角线上出现了不同的值
                }
            }
        }
        return true;
    }
}