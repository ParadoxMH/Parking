using System.Collections.Generic;

namespace Models
{
    public class Parking
    {
        private static Parking instance;

        public int Balance { get; set; }
        public int Capacity { get; set; }
        public int PaymentPeriodicity { get; set; }
        public int FineCoeff { get; set; }
        public List<Vehicle> Cars { get; set; }
        public List<Transaction> Transactions { get; set; }
        
        private Parking()
        { }

        public static Parking GetInstance(int balance)
        {
            if (instance == null)
                instance = new Parking() { Balance = balance };
            return instance;
        }
    }
}
