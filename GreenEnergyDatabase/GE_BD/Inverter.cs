using System;
using System.Collections.Generic;

#nullable disable

namespace GE_DB
{
    public partial class Inverter
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public byte[] Image { get; set; }

        public int Amount_of_phase { get; set; }
        public int Amount_MPP_trackers { get; set; }
        public double MPPT_Voltage_min { get; set; }

        public double Power_min { get; set; }
        public double Power_max { get; set; }
        public double Voltage_max { get; set; }
        public double Voltage_net_min { get; set; }
        public double Voltage_Accumulator { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
