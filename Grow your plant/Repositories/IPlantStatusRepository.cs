using Grow_your_plant.Models;
using System.Collections.Generic;

namespace Grow_your_plant.Repositories
{
    interface IPlantStatusRepository
    {
        void AddStatus(PlantStatus plantStatus);
        PlantStatus GetLastStatus();
        PlantStatus GetInstantStatus();
        List<PlantStatus> GetAllStatuses();
        List<PlantStatus> GetLatestStatuses();
    }
}
