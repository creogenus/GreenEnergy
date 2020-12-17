using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace GE_DB
{
    public partial class Region
    {
        public int Id { get; set; }

        public int Province_ID { get; set; }
        public int InProvince_ID { get; set; }

        public string Name { get; set; }

        //Можно описание

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double GMT_dif { get; set; }


        public double Avg_Temp_Winter { get; set; }
        public double Avg_Temp_Spring { get; set; }
        public double Avg_Temp_Summer { get; set; }
        public double Avg_Temp_Autumn { get; set; }


        public double Avg_Widness_Winter { get; set; }
        public double Avg_Widness_Spring { get; set; }
        public double Avg_Widness_Summer { get; set; }
        public double Avg_Widness_Autumn { get; set; }


        public double Avg_Radiation_Winter { get; set; }
        public double Avg_Radiation_Spring { get; set; }
        public double Avg_Radiation_Summer { get; set; }
        public double Avg_Radiation_Autumn { get; set; }


        public double Avg_Humidity_Winter { get; set; }
        public double Avg_Humidity_Spring { get; set; }
        public double Avg_Humidity_Summer { get; set; }
        public double Avg_Humidity_Autumn { get; set; }


        public double Avg_SunHours_Winter { get; set; }
        public double Avg_SunHours_Spring { get; set; }
        public double Avg_SunHours_Summer { get; set; }
        public double Avg_Sunhours_Autumn { get; set; }


        public double Avg_MainlyCloudyDays_Winter { get; set; }
        public double Avg_MainlyCloudyDays_Spring { get; set; }
        public double Avg_MainlyCloudyDays_Summer { get; set; }
        public double Avg_MainlyCloudyDays_Autumn { get; set; }


        public double Avg_CloudyDays_Winter { get; set; }
        public double Avg_CloudyDays_Spring { get; set; }
        public double Avg_CloudyDays_Summer { get; set; }
        public double Avg_CloudyDays_Autumn { get; set; }


        public double Avg_SynnyDays_Winter { get; set; }
        public double Avg_SunnyDays_Spring { get; set; }
        public double Avg_SunnyDays_Summer { get; set; }
        public double Avg_SunnyDays_Autumn { get; set; }


        public double Avg_Pressure_Winter { get; set; }
        public double Avg_Pressure_Spring { get; set; }
        public double Avg_Pressure_Summer { get; set; }
        public double Avg_Pressure_Autumn { get; set; }


    }
}
