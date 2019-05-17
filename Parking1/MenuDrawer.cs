using System;
using System.Collections.Generic;

namespace Parking1
{
    public class MenuDrawer
    {
        public static int Index { get; set; } = 0;
        public static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == Index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (Index == items.Count - 1)
                {
                    Index = 0; //Remove the comment to return to the topmost item in the list
                }
                else { Index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (Index <= 0)
                {
                    Index = items.Count - 1; //Remove the comment to return to the item in the bottom of the list
                }
                else { Index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[Index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
