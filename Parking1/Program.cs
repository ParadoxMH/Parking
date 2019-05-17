using Parking1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Parking1
{
    class Program
    {
        private static int index = 0;
        static void Main(string[] args)
        {
            List<string> menuItems = new List<string>() {
                "Get current balance",
                "Get sum of profit for the last min",
                "Get parking stats(avail/unavail)",
                "Get all transactions for the last min",
                "Get all transactions",
                "Get all cars",
                "Put a car",
                "Remove a car",
                "Deposit car balance",
                "Exit"
            };
            Console.CursorVisible = false;

            var parking = Parking.GetInstance();


            var timer = new Timer((e) =>
            {
                UpdateTransaction(parking);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            while (true)
            {
                switch (ВrawMenu(menuItems))
                {
                    case "Get current balance":
                        Console.Clear();
                        Console.WriteLine($"Current parking balance is {parking.Balance}$;\r\n\r\nPress any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Get sum of profit for the last min":
                        Console.Clear();

                        double sum = 0;
                        foreach (var tr in parking.Transactions)
                        {
                            sum += tr.Amount;
                        }
                        Console.WriteLine($"Profit for the last min is {sum}$;\r\n\r\nPress any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;

                }
                Console.Clear();
            }
            Console.Read();
        }
        private static void UpdateTransaction(Parking parking)
        {
            parking.Transactions.Add(new Transaction() { Amount = new Random().Next(0, 100)});
            foreach (var trans in parking.Transactions.ToList())
            {
                if(trans.Time < DateTime.Now.AddSeconds(-60))
                {
                    parking.Transactions.Remove(trans);
                }
            }
            //foreach (var tr in parking.Transactions.ToList())    //uncoment to check how its works
            //{
            //    Console.WriteLine($"{tr.Time};");
            //}
            //Console.WriteLine($"Press any key to go back to menu...");
        }
        private static string ВrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
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
                if (index == items.Count - 1)
                {
                    index = 0; //Remove the comment to return to the topmost item in the list
                }
                else { index++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                {
                    index = items.Count - 1; //Remove the comment to return to the item in the bottom of the list
                }
                else { index--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
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
