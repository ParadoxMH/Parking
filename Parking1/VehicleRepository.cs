using Parking1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parking1
{
    public class VehicleRepository
    {
        public static List<Vehicle> worldVehicles = new List<Vehicle>();

        public static void CreateVehicle(Parking parking)
        {
            var vehicle = new Vehicle();
            MenuDrawer.Index = 0;
            var k = true;
            Console.Clear();
            while (k)
            {
                Console.WriteLine("Choose type of Vehicle:");
                var a = MenuDrawer.DrawMenu(new List<string>() { VehicleType.Car.ToString(), VehicleType.Truck.ToString(), VehicleType.Bus.ToString(), VehicleType.Bike.ToString(), "Exit" });

                if (Enum.TryParse(a, out VehicleType type))
                {
                    vehicle.Type = type;
                    k = false;
                }
                if (a == "Exit")
                {
                    MenuDrawer.Index = 0;
                    return;
                }
            }
            MenuDrawer.Index = 0;


            Console.WriteLine("Enter car balance:");
            if (!double.TryParse(Console.ReadLine(), out double bal))
            {
                return;
            }
            vehicle.Balance = bal;
            vehicle.Id = Guid.NewGuid();
            worldVehicles.Add(vehicle);

            Console.WriteLine($"{vehicle.Type.ToString()} was successfuly created!\r\n\r\nPress any key to go back to menu...");
            Console.ReadLine();
        }

        public static void PutVehicle(Parking parking)
        {
            var vehicles = new List<string>();
            foreach (var v in worldVehicles)
            {
                if (!parking.Vehicles.Any(ve => ve.ToString() == v.ToString()))
                {
                    vehicles.Add(v.ToString());
                }
            }

            if (vehicles.Any())
            {
                MenuDrawer.Index = 0;
                string choosedName = "";
                Console.Clear();
                Console.WriteLine("Choose a Vehicle:");
                while (choosedName == "")
                {
                    choosedName = MenuDrawer.DrawMenu(vehicles);
                }
                MenuDrawer.Index = 0;

                var choosedVehicle = worldVehicles.First(v => (v.ToString() == choosedName));
                parking.Vehicles.Add(choosedVehicle);

                double fee = 0;
                switch (choosedVehicle.Type)
                {
                    case VehicleType.Car:
                        fee = ParkingSettings.CarTariff;
                        break;
                    case VehicleType.Truck:
                        fee = ParkingSettings.TruckTariff;
                        break;
                    case VehicleType.Bus:
                        fee = ParkingSettings.BusTariff;
                        break;
                    case VehicleType.Bike:
                        fee = ParkingSettings.BikeTariff;
                        break;
                }

                parking.Transactions.Add(new Transaction()
                {
                    Id = Guid.NewGuid(),
                    Amount = fee,
                    CarId = choosedVehicle.Id,
                    Time = DateTime.Now
                });
            }
            else
            {
                Console.WriteLine("Please create vehicles before putting it..");
                Console.ReadLine();
                return;
            }
        }
    }
}
