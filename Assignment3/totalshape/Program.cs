using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace totalshape
{
    public abstract class Shape
    {
        public abstract int GetArea();
    }
    public class Rectangle : Shape
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public override int GetArea()
        {
            return Length * Width;
        }
    }

    public class Square : Shape
    {
        public int Side { get; set; }
        public override int GetArea()
        {
            return Side * Side;
        }
    }

    public class Triangle : Shape
    {
        public static Triangle NextTriangle()
        {
            Random rnd = new Random();
            int a = Convert.ToInt32(rnd.NextDouble() * 10);
            int b = Convert.ToInt32(rnd.NextDouble() * 10);
            int c = Convert.ToInt32(rnd.NextDouble() * 10);

            while (!IsValidTriangle(a, b, c))
            {
                a = Convert.ToInt32(rnd.NextDouble() * 10);
                b = Convert.ToInt32(rnd.NextDouble() * 10);
                c = Convert.ToInt32(rnd.NextDouble() * 10);
            }

            return new Triangle(a, b, c);
        }

        private static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                return false;
            }

            return true;
        }
    }

    public static class RandomHelper
    {
        static Random rnd = new Random();

        public static int Next()
        {
            return rnd.Next(1,10);
        }

        public static string NextShapeType()
        {
            string[] types = { "rectangle", "square", "triangle" };
            return types[rnd.Next(types.Length)];
        }
    }

    public class ShapeFactory
    {
        public static Shape CreateShape(string type)
        {
            switch (type)
            {
                case "rectangle":
                    return new Rectangle { Length = RandomHelper.Next(), Width = RandomHelper.Next() };
                case "square":
                    return new Square { Side = RandomHelper.Next() };
                case "triangle":
                    return new Triangle { SideA = RandomHelper.Next(), SideB = RandomHelper.Next(), SideC = RandomHelper.Next() };
                default:
                    throw new ArgumentException($"Invalid shape type: {type}");
            }
        }
    }

    class Program
    {
        const int ShapeCount = 10;

        static void Main(string[] args)
        {
            double totalArea = 0;
            for (int i = 0; i < ShapeCount; i++)
            {
                var shape = ShapeFactory.CreateShape(RandomHelper.NextShapeType());
                Console.WriteLine($"Created a {shape.GetType().Name} with area {shape.GetArea()}");
                totalArea += shape.GetArea();
            }
            Console.WriteLine($"Total area: {totalArea}");
        }
    }
}
