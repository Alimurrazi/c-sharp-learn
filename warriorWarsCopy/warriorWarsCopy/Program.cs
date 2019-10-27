using System;
using System.Threading;

namespace warriorWarsCopy
{
    class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Warrior hero = new Warrior("Jasim", Enums.Identity.Hero);
            Warrior villian = new Warrior("Dipjol", Enums.Identity.Villian);

            while(hero.IsAlive && villian.IsAlive)
            {
                if (rng.Next(0, 10) < 5)
                {
                    Console.WriteLine("asob ki....");
                }
                else
                {
                    Console.WriteLine("hisab bujho na....");
                }

                Thread.Sleep(500);
            }
        }
    }
}
