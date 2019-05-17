using System.Collections.Generic;

namespace Parking1.Models
{
    public class Parking
    {
        private static Parking instance;

        public double Balance { get; set; }
        public int Capacity { get; set; }
        public int PaymentPeriodicity { get; set; }
        public double FineCoeff { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Transaction> Transactions { get; set; }
        
        private Parking()
        { }

        public static Parking GetInstance()
        {
            if (instance == null)
                instance = new Parking()
                {
                    Balance = ParkingSettings.DefaultBalance,
                    Capacity = ParkingSettings.MaxCapacity,
                    FineCoeff = ParkingSettings.FineCoeff,
                    PaymentPeriodicity = ParkingSettings.PaymentPeriodicity,
                    Transactions =  new List<Transaction>(),
                    Vehicles = new List<Vehicle>()
                };
            return instance;
        }
    }
}
