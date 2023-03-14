using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shape
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLegal();
    }

    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public override bool IsLegal()
        {
            return Length > 0 && Width > 0 && Length > Width ;
        }
        
        public override double GetArea()
        {
            return Length * Width;
        }
    }

    public class Square : Rectangle
    {
        public double Side
        {
            get => Length;
            set => Length = Width = value;
        }

        public override bool IsLegal()
        {
            return Length > 0 ;
        }
    }

    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public override double GetArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override bool IsLegal()
        {
            return SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[] {
            new Rectangle { Length = 5, Width = 2 },
            new Rectangle { Length = 2, Width = 5 },
            new Square { Side = 4 },
            new Square { Side = -3 },
            new Triangle { SideA = 3, SideB = 4, SideC = 5 },
            new Triangle { SideA = 3, SideB = 4, SideC = 7 },
        };

            foreach (var shape in shapes)
            {
                if (shape.IsLegal())
                {
                    Console.WriteLine($"isLegal,Area: {shape.GetArea()}.");
                }
                else
                {
                    Console.WriteLine("illegal.");
                }
            }
        }
    }
}
