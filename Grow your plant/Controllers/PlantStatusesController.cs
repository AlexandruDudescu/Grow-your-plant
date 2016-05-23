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
        //private IArduinoManager ArduinoManager { get; set; }

        static int x;
        public PlantStatusesController()
        {
            PlantStatusRepository = new PlantStatusRepository();
            //ArduinoManager = new ArduinoManager();
        }

        [HttpPost]
        public void AddNewStatus(PlantStatus newStatus)
        {
            PlantStatusRepository.AddStatus(newStatus);
            GlobalHost.ConnectionManager.GetHubContext<PlantStatusHub>().Clients.All.publishPost(newStatus);
        }

        [HttpGet]
        public List<PlantStatus> GetLastStatuses()
        {
            return PlantStatusRepository.GetLatestStatuses();
        }

        [HttpPost]
        public void GetInstantStatus()
        {
            //PlantStatus instantPlantStatus = ArduinoManager.GetParameters();
            PlantStatus instantPlantStatus = new PlantStatus(1, 1, 1, (x++).ToString());
            
            PlantStatusRepository.AddStatus(instantPlantStatus);
            GlobalHost.ConnectionManager.GetHubContext<PlantStatusHub>().Clients.All.publishPost(instantPlantStatus);
        }
    }
}
