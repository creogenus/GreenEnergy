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

        public static ElectricStation[] CreateConfigurations(double power, double budget)
        {
            List<ElectricStation> buffer_list = new List<ElectricStation>();

            // temporary method

            StreamReader SR_inverter = new StreamReader("test-db-inverter.txt");
            string[] inverter_db = new string[1];
            int amount_inverters = 2;
            string[] accumulator_db = new string[1];
            string[] es_db = new string[1];
            string inverter_string;
            while ((inverter_string = SR_inverter.ReadLine()) != null)
            {
                inverter_db = inverter_string.Split('-');
                if (Convert.ToDouble(inverter_db[1])*amount_inverters <= budget / 4.0)
                {
               
                    string es_string;
                    StreamReader SR_es = new StreamReader("test-db-es.txt");
                    while ((es_string = SR_es.ReadLine()) != null)
                    {
                            es_db = es_string.Split('-');
                        int amount_of_es = Convert.ToInt32(power / Convert.ToDouble(inverter_db[0]));
                        if (Convert.ToDouble(es_db[5]) * amount_of_es <= budget / 2.0)
                        {
                            StreamReader SR_accumulator = new StreamReader("test-db-accumulator.txt");
                            string accum_string;
                            while ((accum_string = SR_accumulator.ReadLine()) != null)
                            {

                                accumulator_db = accum_string.Split('-');
                                int amount_of_accumulator = Convert.ToInt32(power / Convert.ToDouble(accumulator_db[0]));
                                if(Convert.ToDouble(accumulator_db[9]) * amount_of_accumulator <= budget / 4.0)
                                {
                                    Accumulator ac = new Accumulator(amount_of_accumulator, Convert.ToDouble(accumulator_db[0]), Convert.ToDouble(accumulator_db[1]), Convert.ToDouble(accumulator_db[2]), Convert.ToDouble(accumulator_db[3]), Convert.ToDouble(accumulator_db[4]), accumulator_db[5], accumulator_db[6], accumulator_db[7], accumulator_db[8], Convert.ToDouble(accumulator_db[9]));
                                    EnergySource es = new EnergySource(amount_of_es, es_db[0], es_db[1], es_db[2], Convert.ToDouble(es_db[3]), Convert.ToDouble(es_db[4]), Convert.ToDouble(es_db[5]));
                                    Inverter inv = new Inverter(Convert.ToDouble(inverter_db[0]), Convert.ToDouble(inverter_db[1]), inverter_db[2], Convert.ToInt32(inverter_db[3]), Convert.ToDouble(inverter_db[4]), inverter_db[6], Convert.ToDouble(inverter_db[5]), amount_inverters);
                                    ElectricStation estation = new ElectricStation(ac, inv, es, power, budget);
                                    estation.full_cost = Convert.ToDouble(accumulator_db[9]) * amount_of_accumulator + Convert.ToDouble(es_db[5]) * amount_of_es + Convert.ToDouble(inverter_db[1]) * amount_inverters;
                                    estation.full_power = Convert.ToDouble(es_db[4]) * amount_of_es + Convert.ToDouble(inverter_db[0]) * amount_inverters;
                                    buffer_list.Add(estation);
                                }
                            }
                        }
                    }
                }

            }
            return buffer_list.ToArray();       
        }
    }
}
