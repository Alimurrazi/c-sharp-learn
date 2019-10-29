using System;
using System.Collections.Generic;
using System.Text;

namespace warriorWarsCopy
{
    public static class Style
    {
        public static void colorLine(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
