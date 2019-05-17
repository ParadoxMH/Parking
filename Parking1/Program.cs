using Parking1.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                "Vehicle menu",
                "Deposit car balance",
                "Exit"
            };
            Console.CursorVisible = false;

            var parking = Parking.GetInstance();


            var timer = new Timer((e) =>
            {
                UpdateTransaction(parking);
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            MenuDrawer.Index = 0;
            while (true)
            {
                switch (MenuDrawer.DrawMenu(menuItems))
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
                    case "Get parking stats(avail/unavail)":
                        Console.Clear();
                        Console.WriteLine($"Currently available {parking.Capacity - parking.Vehicles.Capacity} parkings;\r\n\r\nPress any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Get all transactions for the last min":
                        Console.Clear();
                        Console.WriteLine($"All transactions for the last min:");
                        foreach (var tr in parking.Transactions)
                        {
                            Console.WriteLine(tr);
                        }
                        Console.WriteLine("Press any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Get all transactions":
                        Console.Clear();
                        ShowAllTransactions();
                        Console.WriteLine("Press any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Get all cars":
                        Console.Clear();
                        foreach (var car in parking.Vehicles)
                        {
                            Console.WriteLine(car);
                        }
                        Console.WriteLine("Press any key to go back to menu...");
                        Console.Read();
                        break;
                    case "Vehicle menu":
                        Console.Clear();
                        CarMenu(parking);
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
            parking.Transactions.Add(new Transaction() { Amount = new Random().Next(0, 100), Id = Guid.NewGuid()});
            foreach (var trans in parking.Transactions.ToList())
            {
                if(trans.Time < DateTime.Now.AddSeconds(-30))
                {
                    WriteTransToLog(trans);
                    parking.Transactions.Remove(trans);
                }
            }
            //foreach (var tr in parking.Transactions.ToList())    //uncoment to check how its works
            //{
            //    Console.WriteLine($"{tr.Time};");
            //}
            //Console.WriteLine($"Press any key to go back to menu...");
        }
        private static void ShowAllTransactions()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader($"{Directory.GetCurrentDirectory()}\\transLog.txt");

                Console.WriteLine($"All transactions for the last min:");
                line = sr.ReadLine();
                
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
            }

        }
        private static void WriteTransToLog(Transaction transaction)
        {
            using (StreamWriter w = File.AppendText($"{Directory.GetCurrentDirectory()}\\transLog.txt"))
            {
                w.WriteLine(transaction);
            }
        }
        private static void CarMenu(Parking parking)
        {
            MenuDrawer.Index = 0;
            while (true)
            {
                switch (MenuDrawer.DrawMenu(new List<string>() { "Create vehicle", "Put vehicle", "Delete vehicle", "Remove vehicle", "Exit" }))
                {
                    case "Create vehicle":
                        VehicleRepository.CreateVehicle(parking);
                        break;
                    case "Put vehicle":
                        VehicleRepository.PutVehicle(parking);
                        break;
                    case "Delete vehicle":

                        break;
                    case "Remove vehicle":

                        break;
                    case "Exit":
                        MenuDrawer.Index = 0;
                        return;
                }
                Console.Clear();
            }
        }
    }
}
//transact should be added to log file and parking collection while it was created;