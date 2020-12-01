using System;
using System.Collections.Generic;

#nullable disable

namespace GE_BD
{
    public partial class EnergySource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public double Voltage { get; set; }
        public double Amperage { get; set; }
        public double Price { get; set; }
    }
}
