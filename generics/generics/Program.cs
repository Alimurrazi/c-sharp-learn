using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics
{

    public class GFG<T>
    {
        private T data;

        public T value
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GFG<string> example = new GFG<string>();
            example.value = "avro";

            GFG<float> version = new GFG<float>();
            version.value = 6.50F;

            Console.WriteLine(example.value);
            Console.WriteLine(version.value);
            Console.ReadKey();
        }
    }
}
