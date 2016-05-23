using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grow_your_plant.Models
{
    public class PlantStatus
    {
        [Key]
        public int PlantStatudID { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Luminosity { get; set; }

        public string StatusTime { get; set; }

        public PlantStatus(double temperature, double humidity, double luminosity, string statusTime)
        {
            Temperature = temperature;
            Humidity = humidity;
            Luminosity = luminosity;
            StatusTime = statusTime;
        }

        public PlantStatus()
        {

        }
    }
}