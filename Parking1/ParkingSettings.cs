using Microsoft.Extensions.Configuration;
using System.IO;

namespace Parking1
{
    public static class ParkingSettings
    {
        static IConfiguration config;
        public static double DefaultBalance
        {
            get
            {
                if (double.TryParse(config["DefaultBalance"], out double res))
                    return res;
                return 0;
            }
        }
        public static int MaxCapacity
        {
            get
            {
                if (int.TryParse(config["MaxCapacity"], out int res))
                    return res;
                return 10;
            }
        }
        public static int PaymentPeriodicity
        {
            get
            {
                if (int.TryParse(config["PaymentPeriodicity"], out int res))
                    return res;
                return 5;
            }
        }
        public static double FineCoeff
        {
            get
            {
                if (double.TryParse(config["FineCoeff"], out double res))
                    return res;
                return 2.5;
            }
        }

        public static double CarCoeff
        {
            get
            {
                if (double.TryParse(config["CarCoeff"], out double res))
                    return res;
                return 2;
            }
        }
        public static double TruckCoeff
        {
            get
            {
                if (double.TryParse(config["TruckCoeff"], out double res))
                    return res;
                return 5;
            }
        }
        public static double BusCoeff
        {
            get
            {
                if (double.TryParse(config["BusCoeff"], out double res))
                    return res;
                return 3.5;
            }
        }
        public static double BikeCoeff
        {
            get
            {
                if (double.TryParse(config["BikeCoeff"], out double res))
                    return res;
                return 1;
            }
        }
        public static double CarTariff
        {
            get
            {
                if (double.TryParse(config["CarTariff"], out double res))
                    return res;
                return 2;
            }
        }
        public static double TruckTariff
        {
            get
            {
                if (double.TryParse(config["TruckTariff"], out double res))
                    return res;
                return 5;
            }
        }
        public static double BusTariff
        {
            get
            {
                if (double.TryParse(config["BusTariff"], out double res))
                    return res;
                return 3.5;
            }
        }
        public static double BikeTariff
        {
            get
            {
                if (double.TryParse(config["BikeTariff"], out double res))
                    return res;
                return 1;
            }
        }

        static ParkingSettings()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");

            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
        }
    }
}
