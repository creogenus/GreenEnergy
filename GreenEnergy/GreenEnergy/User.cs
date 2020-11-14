using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenEnergy
{
    public class User
    {
        double budget;
        double power;
        Region region;
        string chosen_region;

        public User(Region rg)
        {
            region = rg;
            chosen_region = rg.GetName();
            //не хвататет выбранных значений для бюджета и мощности
        }
        
        public User(double bdgt, Region rg)
        {
            double budget = bdgt;
            region = rg;
            chosen_region = rg.GetName();
            //не хвататет выбранного значения для мощности
        }

        public User(Region rg, double pwr)
        {
            power = pwr;
            region = rg;
            chosen_region = rg.GetName();
            //не хвататет выбранного значения для бюджета
        }

        public User(double bdgt, double pwr, Region rg)
        {
            budget = bdgt;
            power = pwr;
            region = rg;
            chosen_region = rg.GetName();
        }

    }
}
