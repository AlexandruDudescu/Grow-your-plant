﻿using Grow_your_plant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Grow_your_plant.Repositories
{
    public class PlantStatusContext : DbContext
    {
        public DbSet<PlantStatus> PlantStatuses { get; set; }
        //public DbSet<IdealPlantStatus> IdealPlantStatuses { get; set; }

        public PlantStatusContext(): base("name=PlantDbConnectionString")
        {

        }
    }
}