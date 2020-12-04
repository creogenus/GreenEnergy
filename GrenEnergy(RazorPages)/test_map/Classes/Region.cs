using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test_map
{
    public class Region
    {
        string name;
        public double intensity { get; set; }
        public double windiness { get; set; }
        public double average_temperature { get; set; }
        public double humidity { get; set; }


        public Region(string n)
        {
            name = n;
            //функционал временного формирования региона, в будущем данные будут браться из БД

            StreamReader SR = new StreamReader("test-db-region.txt");
            bool stop = false;
            while(!stop)
            {
                string [] buffer_array = SR.ReadLine().Split('-');
                if (name == buffer_array[0])
                {
                    intensity = Convert.ToDouble(buffer_array[1]);
                    windiness = Convert.ToDouble(buffer_array[2]);
                    average_temperature = Convert.ToDouble(buffer_array[3]);
                    humidity = Convert.ToDouble(buffer_array[4]);
                    stop = true;
                }
            }
            SR.Close();
        }

        public string GetName()
        {
            return name;
        }
    }
}
