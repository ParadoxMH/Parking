
using System;

namespace Parking1.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public double Balance { get; set; }
        public VehicleType Type { get; set; }

        public override string ToString()
        {
            return $"Vehicle Id: {Id}; Balance: {Balance}; Type: {Type.ToString()}";
        }
    }
}
