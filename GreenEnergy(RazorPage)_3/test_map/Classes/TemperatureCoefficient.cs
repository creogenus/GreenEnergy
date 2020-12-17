using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class TemperatureCoefficient
    {
        public double T_bat(double T_air, double T_lab, double Hum, double Press,double SPD, double SR_bat, double SR_lab)
        {
            return T_lab + 0.81 * (T_air - T_lab) - 0.06 * Hum - 0.01 * Press - 0.24 * SPD + 0.06 * (SR_bat - SR_lab);
        }

        public double temp_k(double T_bat, double T_lab, double a_coeff)
        {
            if ((T_bat - T_lab) > 0)
                return (100 - (a_coeff * (T_bat - T_lab)))/100;
            else
            {
                return 1;
            }
        }
    }
}
