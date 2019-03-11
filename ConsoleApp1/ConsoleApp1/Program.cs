using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static string value = "Welcome";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Program.value);
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(n);
            add(ref n);
            Console.WriteLine(n);
            greet(3,"John", "Jonny", "jack");
            Console.ReadLine();
        }

        static void add(ref int n)
        {
            n = n + 5;
        }

        static void greet(int n,params string[] names)
        {
            Console.WriteLine("total "+n);
            foreach (string name in names)
                Console.WriteLine("Hello ..."+name);
        }

    }
}
