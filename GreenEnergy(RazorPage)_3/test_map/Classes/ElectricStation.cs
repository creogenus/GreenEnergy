using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test_map
{
    public class ElectricStation
    {

        public double budget { get; set; }
        public  double power { get; set; }
        public Accumulator accumulator { get; set; }
        public Inverter inverter { get; set; }
        public EnergySource esource { get; set; }
        public double efficiency { get; set; }
        public double full_cost { get; set; }
        public double full_power { get; set; }

        public ElectricStation(double power)
        {
            this.power = power;
            //
        }
        public ElectricStation(double power, double budget)
        {
            this.budget = budget;
            this.power = power;
        }

        public ElectricStation(Accumulator acum, Inverter inv, EnergySource es, double power, double budget)
        {
            this.accumulator = acum;
            this.inverter = inv;
            this.esource = es;
            this.budget = budget;
            this.power = power; 
        }

        public static GEDatabase gE = GEDatabase.Init("Server=(localdb)\\mssqllocaldb;Database=GE_BD;Trusted_Connection=True;");

        public static ElectricStation[] CreateConfigurations(double power, double budget)
        {
            List<ElectricStation> buffer_list = new List<ElectricStation>();
            List<int> es = gE.EnergySourceIds();
            List<int> accum = gE.AccumlatorIds();
            List<int> inverter = gE.InverterIds();

            foreach(int e_s in es)
            {
                foreach(int ac in accum)
                {
                    foreach(int inv in inverter)
                    {
                        ElectricStation e_station =
                            new ElectricStation(gE.AccumulatorFind(ac), gE.InverterFind(inv), gE.EnergySourceFind(e_s), power, budget
                            );
                        e_station.full_cost = e_station.accumulator.Price + e_station.esource.Price + e_station.inverter.Price;
                        buffer_list.Add(e_station);
                    }
                }
            }
            return buffer_list.ToArray();       
        }
    }
}
