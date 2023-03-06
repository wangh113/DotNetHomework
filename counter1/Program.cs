using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("请输入第一个数字：");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("请输入运算符：");
            string choice = Console.ReadLine();

            Console.Write("请输入第二个数字：");
            double num2 = double.Parse(Console.ReadLine());

            switch (choice)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", num1, num2, num1 + num2);
                    break;

                case "-":
                    Console.WriteLine("{0} - {1} = {2}", num1, num2, num1 - num2);
                    break;

                case "*":
                    Console.WriteLine("{0} * {1} = {2}", num1, num2, num1 * num2);
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("错误：除数不能为0");
                    }
                    else
                    {
                        Console.WriteLine("{0} / {1} = {2}", num1, num2, num1 / num2);
                    }
                    break;

                default:
                    Console.WriteLine("无效的选择");
                    break;
            }

            Console.ReadLine();
        }
    }
}