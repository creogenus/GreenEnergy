using System;
using System.Collections.Generic;

#nullable disable

namespace test_map
{
    public partial class Accumulator
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public double Price { get; set; }

        public byte [] Image { get; set; }

        public double Capacity { get; set; }
        public double Resource { get; set; }

        public double Power { get; set; }
        public double Voltage { get; set; }
        public double Amperage { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
    }
}
