using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Data
    {
        public static void BannerText(int x, int y)
        {
            Pos(x, y, @"    Lommeregner", ConsoleColor.White);
        }
        public static void Banner(int x, int y)
        {
            Pos(x, y + 0, @"*************************", ConsoleColor.Red);
            Pos(x, y + 1, @"*", ConsoleColor.Red);
            Pos(x + 24, y + 1, @"*", ConsoleColor.Red);
            Pos(x, y + 2, @"*************************", ConsoleColor.Red);
        }



            public static void NumLockKeys(int x, int y)
        {
            Pos(x, y + 0, @"┌───────────────────────┐", ConsoleColor.Yellow);
            Pos(x, y + 1, @"│                       │", ConsoleColor.Yellow);
            Pos(x, y + 2, @"├─────┬─────┬─────┬─────┤", ConsoleColor.Yellow);
            Pos(x, y + 3, @"│  7  │  8  │  9  │  *  │", ConsoleColor.Yellow);
            Pos(x, y + 4, @"├─────┼─────┼─────┼─────┤", ConsoleColor.Yellow);
            Pos(x, y + 5, @"│  4  │  5  │  6  │  /  │", ConsoleColor.Yellow);
            Pos(x, y + 6, @"├─────┼─────┼─────┼─────┤", ConsoleColor.Yellow);
            Pos(x, y + 7, @"│  1  │  2  │  3  │  -  │", ConsoleColor.Yellow);
            Pos(x, y + 8, @"├─────┼─────┼─────┼─────┤", ConsoleColor.Yellow);
            Pos(x, y + 9, @"│  0  │  C  │  =  │  +  │", ConsoleColor.Yellow);
            Pos(x, y + 10, @"└─────┴─────┴─────┴─────┘", ConsoleColor.Yellow);

        }

        public static void MarkedOperator(int x, int y)
        {
            Pos(x + 2, y + 1, @"[+]", ConsoleColor.Blue);

        }


        public static void Pos(int x, int y, object tekst, ConsoleColor color = ConsoleColor.White) //positioning text
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(tekst);
            //Console.ResetColor();
        }
    }
}
