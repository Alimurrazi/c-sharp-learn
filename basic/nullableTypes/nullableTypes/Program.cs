using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int? nullable = null;
            if(nullable.HasValue)
                Console.WriteLine(nullable);

           
            nullable = 33;
            Console.WriteLine(nullable.Value);
            Console.ReadKey();
        }
    }
}
