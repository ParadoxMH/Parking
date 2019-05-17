using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int CarId { get; set; }
        public double Amount { get; set; }
    }
}
