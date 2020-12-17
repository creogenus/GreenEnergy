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
           
            ElectricStation[] all_stations = ElectricStation.CreateConfigurations(estation.power,estation.budget);
            // temp method of calculation

            for(int i = 0;  i < all_stations.Length; i++)
            {
                all_stations[i].efficiency = all_stations[i].full_power / (all_stations[i].full_cost * region.average_temperature * 0.01 * region.humidity * 0.005 * region.intensity * 0.1 * region.windiness * 0.0003);
            }
            ElectricStation[] top_stations = all_stations;
            //need sort function
            //
            //
            //
            //
            //
            return top_stations;
        }
    }
}
