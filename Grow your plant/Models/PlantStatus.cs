using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grow_your_plant.Models
{
    public class PlantStatus
    {
        public double Temperature { get; set; }
        public double Umidity { get; set; }
        public double Luminosity { get; set; }

        public PlantStatus(double temperature, double umidity, double luminosity)
        {
            Temperature = temperature;
            Umidity = umidity;
            Luminosity = luminosity;
        }

        public PlantStatus()
        {

        }
    }
}