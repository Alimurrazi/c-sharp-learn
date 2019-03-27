using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new asynAwaitDemo();
            Task.WaitAll(demo.doStuff());
            //while(true)
            //{
            //    Console.WriteLine("doing stuff in main thread.................");
            //}
        }
    }

    public class asynAwaitDemo
    {
        public async Task doStuff()
        {
            //string str;
            //await Task.Run(() =>
            //{
            //    longrunning();
            //});
            //for(int i=0;i<10;i++)
            //Console.WriteLine("hello.....");
            Console.WriteLine("Async Application Started!");
            Task<string> greetmsg = longrunning();
            Console.WriteLine("Async Method in started....");

            Console.WriteLine("Current Time: " + DateTime.Now);
            Console.WriteLine("Awaiting result from Async method...");
            string msg = await greetmsg;
            Console.WriteLine("Async method completed!");
            Console.WriteLine("Current Time: " + DateTime.Now);
            Console.WriteLine("Async method output: " + greetmsg.Result);

            Console.WriteLine("Async Application Ended!");
            Console.Read();
        }

        private static async Task<string> longrunning()
        {
            //int counter;
            //for(counter=0;counter<50000;counter++)
            //{
            //   // Console.WriteLine(counter);
            //}
            //Console.ReadLine();
            //return "counter=" + counter;
            await Task.Delay(10000);
            return "welcome to ......";
        }
    }
}
