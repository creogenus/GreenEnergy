using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class PowerPanelCaluclation
    {
        public double CalculatePower(double panel_power, double inverter_efficiency, double T_air,
               double T_lab, double a_coefficient, double Hum, double SPD, double Press, double SR_region,
                double SR_lab, double lon_deg, double lon_min, double lon_sec, double lat_deg, double lat_min,
                double lat_sec, double avg_sunny_hour)
        {


            int cl_d = 35;
            int m_cl_d = 10;
            int sun_d = 36;
            DateTime date = new DateTime(2020, 6, 13, 12, 0, 0);
            CurrentAngle ang_k = new CurrentAngle();
            CloudCoefficient cl_k = new CloudCoefficient();
            RadiationCoefficient rad_k = new RadiationCoefficient();
            TemperatureCoefficient temp_k = new TemperatureCoefficient();

            return panel_power *
                temp_k.temp_k(
                    temp_k.T_bat(T_air, T_lab, Hum, Press, SPD, SR_region, SR_lab),
                    T_lab, a_coefficient) * 
                    ang_k.Angle_Coefficient(lon_deg, lon_min, lon_sec, lat_deg, lat_min, lat_sec, date) *
                    avg_sunny_hour*inverter_efficiency;

        }
    }               
}
