using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extension_method
{

    public static class Program
    {
        public static bool isGreaterThan(this int i)
        {
            return i > 10;
        }

        static void Main(string[] args)
        {
            int i = 10;
            bool result = i.isGreaterThan();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
