using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace GreenEnergy
{
    public class Inverter
    {
        double power;
        double price;
        string brand;
        double voltage;
        int amount_of_inputs;
        double amount_of_phase;
        string name;
        int amount_of_inverters;


        public Inverter(double price, double power, string brand, int amount_of_inputs, double amount_of_phase, string name, double voltage, int amount_inv)
        {
            this.power = power;
            this.price = price;
            this.voltage = voltage;
            this.brand = brand;
            this.amount_of_inputs = amount_of_inputs;
            this.amount_of_phase = amount_of_phase;
            this.name = name;
            this.amount_of_inverters = amount_inv;
        }
    }
}
