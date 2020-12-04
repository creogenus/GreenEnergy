using System;
using System.Collections.Generic;

#nullable disable

namespace GE_BD
{
    public partial class Accumulator
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double Price { get; set; }
        public string Material { get; set; } 
        public string Type_of_Terminal { get; set; }
        public string Technology { get; set; }
        public double Voltage { get; set; }
    }
}
