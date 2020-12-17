using System;
using System.Collections.Generic;

#nullable disable

namespace GE_DB
{
    public partial class EnergySource
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }
        
        public object Image { get; set; }

        public double Voltage_work { get; set; }
        public double Amperage_work { get; set; }

        public double Short_circuit_Amperage { get; set; }

        public double Voltage_max { get; set; }
        public double Amperage_max { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }

    }
}
