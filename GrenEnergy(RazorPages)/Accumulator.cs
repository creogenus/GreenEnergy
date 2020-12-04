using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenEnergy
{
    public class Accumulator
    {
        int amount;
        double capacity; 
        double weight; 
        double guarantee; 
        double voltage; 
        double resource;  
        string technology;
        string type_of_terminal; 
        string brand; 
        string name; 
        double price; 

        public Accumulator(int amount, double capacity, double weight, double guarantee,double voltage, double resource, string technology, string type_of_terminal, string brand, string name, double price)
        {
            this.amount = amount;
            this.capacity = capacity;
            this.weight = weight;
            this.guarantee = guarantee;
            this.voltage = voltage;
            this.resource = resource;
            this.technology = technology;
            this.type_of_terminal = type_of_terminal;
            this.name = name;
            this.price = price * amount;
        }

    }
}
