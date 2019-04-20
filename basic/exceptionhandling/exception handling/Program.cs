using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exception_handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] ara = new int[2];
                ara[0] = 1;
                ara[1] = 2;
                ara[2] = 3;
                foreach (int i in ara)
                    Console.WriteLine(i);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("What the hell....");
            }
            catch (Exception ex)
            {
                Console.WriteLine("wrong..."+ex.Message);
                Console.WriteLine("error type..." + ex.GetType().ToString());
            }
            finally
            {
                Console.WriteLine("sob kota janala khule dao na...");
            }
            Console.ReadLine();
        }
    }
}
