using Grow_your_plant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grow_your_plant.Arduino
{
    interface IArduinoManager
    {
        PlantStatus GetPlantStatus();
       
    }
}
