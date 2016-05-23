using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Grow_your_plant.Models
{
    public class IdealPlantStatus
    {
        [Key]
        public int IdealPlantStatudID { get; set; }
        public double IdealTemperature { get; set; }
        public double IdealHumidity { get; set; }
        public double IdealLuminosity { get; set; }

        public IdealPlantStatus(double temperature, double humidity, double luminosity)
        {
            IdealTemperature = temperature;
            IdealHumidity = humidity;
            IdealLuminosity = luminosity;
        }

        public IdealPlantStatus()
        {

        }
    }
}