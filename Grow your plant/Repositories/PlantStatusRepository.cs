using System;
using System.Collections.Generic;
using System.Linq;
using Grow_your_plant.Models;

namespace Grow_your_plant.Repositories
{
    public class PlantStatusRepository : IPlantStatusRepository
    {

        private PlantStatusContext PlantStatusContext { get; set; }

        public PlantStatusRepository()
        {
            PlantStatusContext = new PlantStatusContext();
        }

        public void AddStatus(PlantStatus plantStatus)
        {
            PlantStatusContext.PlantStatuses.Add(plantStatus);
            PlantStatusContext.SaveChanges();
        }

        public List<PlantStatus> GetAllStatuses()
        {
            return PlantStatusContext.PlantStatuses.ToList();
        }

        public List<PlantStatus> GetLatestStatuses()
        {
            return PlantStatusContext.PlantStatuses.Take(5).ToList();
        }

        public PlantStatus GetLastStatus()
        {
            throw new NotImplementedException();
        }
    }
}