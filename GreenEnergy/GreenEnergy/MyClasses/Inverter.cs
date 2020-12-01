using System;
using System.Collections.Generic;

#nullable disable

namespace GE_BD
{
    public partial class Inverter
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Voltage { get; set; }
        public double Amperage { get; set; }
        public double Price { get; set; }
        public int Amount_of_inputs { get; set; }
        public double Amount_of_phase { get; set; }
        public int Amount_of_inverters { get; set; }
    }
}
