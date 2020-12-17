using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class User
    {
        public double budget { get; set; }
        public double power { get; set; }
        public Region region { get; set; }
        string chosen_region;

        public User(Region rg)
        {
            region = rg;
            chosen_region = rg.Name;
            //не хвататет выбранных значений для бюджета и мощности
        }
        
        public User(double bdgt, Region rg)
        {
            double budget = bdgt;
            region = rg;
            chosen_region = rg.Name;
            //не хвататет выбранного значения для мощности
        }

        public User(Region rg, double pwr)
        {
            power = pwr;
            region = rg;
            chosen_region = rg.Name;
            //не хвататет выбранного значения для бюджета
        }

        public User(double bdgt, double pwr, Region rg)
        {
            budget = bdgt;
            power = pwr;
            region = rg;
            chosen_region = rg.Name;
        }

    }
}
