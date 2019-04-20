using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    class Program
    {
        public delegate void print(int value);
        static void Main(string[] args)
        {
            print add = printAdd;
            add(10);
            add = printRemove;
            add(10);
          //  printAdd(10);
        }
        public static void printAdd(int n)
        {
            Console.WriteLine(n + 10);
            Console.ReadKey();
        }
        public static void printRemove(int n)
        {
            Console.WriteLine(n - 10);
            Console.ReadKey();
        }
    }
}
