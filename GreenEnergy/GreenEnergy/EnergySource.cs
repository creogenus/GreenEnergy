using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenEnergy
{
    public class EnergySource
    {
        int amount; 
        string brand; 
        string name; 
        string material; 
        double voltage; 
        double amperage; 
        double price; 
        public EnergySource(int amount, string brand, string name, string material, double voltage, double amperage, double price)
        {
            this.amount = amount;
            this.brand = brand;
            this.name = name;
            this.material = material;
            this.voltage = voltage;
            this.amperage = amperage;
            this.price = price*amount;
        }
    }
}
