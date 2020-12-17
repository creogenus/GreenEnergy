using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_map
{
    public class Efficiency
    {
        ElectricStation estation;
        Region region;

        public Efficiency(ElectricStation estation, Region region)
        {
            this.estation = estation;
            this.region = region;     
        }

        public ElectricStation [] CalculateMostEfficientStation()
        {
            PowerPanelCaluclation power_cal = new PowerPanelCaluclation();
            ElectricStation[] all_stations = ElectricStation.CreateConfigurations(estation.power,estation.budget);
            List<ElectricStation> top_stations = new List<ElectricStation>();
            // temp method of calculation
            for (int i = 0; i < all_stations.Length; i++)
            {
            
                if (power_cal.CalculatePower(all_stations[i].esource.Amperage_work * all_stations[i].esource.Voltage_work,
                        all_stations[i].inverter.Efficiency, region.Avg_Temp_Summer, 25, all_stations[i].esource.A_Coefficient, region.Avg_Humidity_Summer,
                        region.Avg_Widness_Summer, region.Avg_Pressure_Summer, region.Avg_Radiation_Summer, 1000, region.Longitude_degrees,
                        region.Longitude_minutes, region.Longitude_seconds, region.Latitude_degrees, region.Latitude_minutes, region.Latitude_seconds,
                        region.Avg_SunHours_Summer)>all_stations[i].power)
                {
                    top_stations.Add(all_stations[i]);
                }
            }


            return top_stations.ToArray();
        }
    }
}
