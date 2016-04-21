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
        public double Umidity { get; set; }
        public double Luminosity { get; set; }

        public string StatusTime { get; set; }

        public PlantStatus(double temperature, double umidity, double luminosity)
        {
            Temperature = temperature;
            Umidity = umidity;
            Luminosity = luminosity;
            StatusTime = DateTime.UtcNow.ToString();
        }

        public PlantStatus()
        {

        }
    }
}