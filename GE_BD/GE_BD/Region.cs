using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace GE_BD
{
    public partial class Region
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Intensity { get; set; }
        public double Windiness { get; set; }
        public double Average_temperature { get; set; }
        public double Humidity { get; set; }
        public double Sunshine { get; set; }
    }
}
