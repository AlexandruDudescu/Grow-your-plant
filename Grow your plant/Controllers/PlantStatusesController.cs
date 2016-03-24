using Grow_your_plant.Hubs;
using Grow_your_plant.Models;
using Grow_your_plant.Repositories;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Web.Http;

namespace Grow_your_plant.Controllers
{
    public class PlantStatusesController : ApiController
    {
        private IPlantStatusRepository PlantStatusRepository { get; set; }

        public PlantStatusesController()
        {
            PlantStatusRepository = new PlantStatusRepository();
        }

        [HttpPost]
        public void AddEmployee(PlantStatus newStatus)
        {
            PlantStatusRepository.AddStatus(newStatus);
            GlobalHost.ConnectionManager.GetHubContext<PlantStatusHub>().Clients.All.publishPost(newStatus);
        }

        [HttpGet]
        public List<PlantStatus> GetLastStatuses()
        {
            return PlantStatusRepository.GetLatestStatuses();
        }
    }
}
