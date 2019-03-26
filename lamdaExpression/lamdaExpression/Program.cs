using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lamdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ara = { 1, 2, 3, 4, 5, 6 };
            double average = ara.Where(n => n % 2 == 1).Average();
            Console.WriteLine(average);
            Console.ReadLine();
        }
    }
}
