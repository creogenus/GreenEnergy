using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class RadiationCoefficient
    {
        public double Rad_Coefficient(double SR_lab, double SR_region)
        {
            return SR_region / SR_lab;
        }
    }
}
