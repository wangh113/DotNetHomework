using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> doubleList = new List<double>() { 1.5, 2.3, 3.6, 4.2, 5.1 };
            doubleList.ForEach(d => Console.WriteLine($"Double number: {d}"));

            double max = Double.MinValue;
            double min = Double.MaxValue;
            double sum = 0.0;
            doubleList.ForEach(d =>
            {
                if (d > max)
                {
                    max = d;
                }
                if (d < min)
                {
                    min = d;
                }
                sum += d;
            });
            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");
        }
    }

    public class MyList<T>
    {
        private List<T> items;

        public MyList()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void ForEach(Action<T> action)
        {
            foreach (T item in items)
            {
                action(item);
            }
        }
    }
}