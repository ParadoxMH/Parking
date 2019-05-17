using System;

namespace Parking1.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int CarId { get; set; }
        public double Amount { get; set; }

        public Transaction()
        {
            Time = DateTime.Now;
        }
    }
}
