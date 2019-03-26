using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic user = new
            {
                name = "john doe",
                age = 42,
        };
            Console.WriteLine(user.GetType());
            user = 456;
            Console.WriteLine(user.GetType());
            Console.ReadKey();
        }
    }
}
