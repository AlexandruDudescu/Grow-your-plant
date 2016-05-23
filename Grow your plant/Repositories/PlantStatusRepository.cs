using System;
using System.Collections.Generic;
using System.Linq;
using Grow_your_plant.Models;
using System.Data.Entity;


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
            List<PlantStatus> plantStatusList = PlantStatusContext.PlantStatuses.OrderByDescending(p => p.PlantStatudID).Take(5).ToList();
            plantStatusList.Reverse();

            return plantStatusList;
        }

        public PlantStatus GetLastStatus()
        {
            throw new NotImplementedException();
        }

        public PlantStatus GetInstantStatus()
        {
            throw new NotImplementedException();
        }
    }
}