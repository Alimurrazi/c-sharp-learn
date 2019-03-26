using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            addNumbers a = new addNumbers();
            a.ev_OddNumber += new addNumbers.dg_OddNumber(EventMsg);
            a.add(10, 5);
            Console.ReadKey();
        }

        static void EventMsg()
        {
            Console.WriteLine("*******Event Executed**********");
        }
    }

    class addNumbers
    {
        public delegate void dg_OddNumber();
        public event dg_OddNumber ev_OddNumber;

        public void add(int a,int b)
        {
            int result;
            result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
            {
                ev_OddNumber();
            }
        }
    }
}
