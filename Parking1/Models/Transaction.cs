using System;

namespace Parking1.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Guid CarId { get; set; }
        public double Amount { get; set; }

        public Transaction()
        {
            Time = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Trans Id: {Id}; Cretion time: {Time.ToShortTimeString()}; Car Id: {CarId}; Amount: {Amount}$";
        }
    }
}
