using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GreenEnergy
{
    public class ElectricStation
    {

        public double budget { get; set; }
        public  double power { get; set; }
        Accumulator accumulator;
        Inverter inverter;
        EnergySource esource;
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
            string[] inverter_db = SR_inverter.ReadLine().Split(',');
            int amount_inverters = 2;           
            while (SR_inverter.ReadLine() != "")
            {

                if (Convert.ToDouble(inverter_db[1])*amount_inverters <= budget / 4)
                {
                    StreamReader SR_es = new StreamReader("test-db-es.txt");
                    string es_string;
                    while ((es_string = SR_es.ReadLine()) != "")
                    {
                        string[] es_db = es_string.Split(',');
                        int amount_of_es = Convert.ToInt32(power / Convert.ToDouble(inverter_db[0]));
                        if (Convert.ToDouble(es_db[6]) * amount_of_es <= budget / 2)
                        {
                            StreamReader SR_accumulator = new StreamReader("test-db-accumulator.txt");
                            string accum_string;
                            while ((accum_string = SR_accumulator.ReadLine()) != "")
                            {
                                string[] accumulator_db = accum_string.Split(',');
                                int amount_of_accumulator = Convert.ToInt32(power / Convert.ToDouble(accumulator_db[0]));
                                if(Convert.ToDouble(accumulator_db[10]) * amount_of_accumulator <= budget / 4)
                                {
                                    Accumulator ac = new Accumulator(amount_of_accumulator, Convert.ToDouble(accumulator_db[1]), Convert.ToDouble(accumulator_db[2]), Convert.ToDouble(accumulator_db[3]), Convert.ToDouble(accumulator_db[4]), Convert.ToDouble(accumulator_db[5]), accumulator_db[6], accumulator_db[7], accumulator_db[8], accumulator_db[9], Convert.ToDouble(accumulator_db[10]));
                                    EnergySource es = new EnergySource(amount_of_es, es_db[0], es_db[1], es_db[2], Convert.ToDouble(es_db[3]), Convert.ToDouble(es_db[4]), Convert.ToDouble(es_db[5]));
                                    Inverter inv = new Inverter(Convert.ToDouble(inverter_db[0]), Convert.ToDouble(inverter_db[1]), inverter_db[2], Convert.ToInt32(inverter_db[3]), Convert.ToInt32(inverter_db[4]), inverter_db[5], Convert.ToDouble(inverter_db[6]), amount_inverters);
                                    ElectricStation estation = new ElectricStation(ac, inv, es, power, budget);
                                    estation.full_cost = Convert.ToDouble(es_db[10]) * amount_of_es + Convert.ToDouble(es_db[6]) * amount_of_es + Convert.ToDouble(inverter_db[1]) * amount_inverters;
                                    estation.full_power = Convert.ToDouble(es_db[4]) * amount_of_es + Convert.ToDouble(es_db[0]) * amount_inverters;
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
