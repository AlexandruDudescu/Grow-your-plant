using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

using Grow_your_plant.Models;
using Grow_your_plant.Arduino;

namespace SocialNeGrow_your_plant.Console
{
    class Program
    {         
        private static DateTime startTime = DateTime.Now;
        private static TimeSpan spanTime = TimeSpan.FromSeconds(5);
        private static IArduinoManager ArduinoManager;

        static void Main()
        {
            ArduinoManager = new ArduinoManager();

            while(true)
            {
                while (DateTime.Now < startTime + spanTime);
                PlantStatus CurrentPlantStatus = ArduinoManager.GetPlantStatus();
                PostAsync(CurrentPlantStatus).Wait();
                startTime = DateTime.Now;
            }
        }
        
        static async Task PostAsync(PlantStatus plantStatus)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56284");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Http post
                HttpResponseMessage response = await client.PostAsJsonAsync("api/PlantStatuses/AddNewStatus", plantStatus);

                if(response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Status Posted succesfully!");
                    PrintPost(plantStatus);
                }
                else
                {
                    System.Console.WriteLine("Attept unsuccesfull!");
                }
            }
        }

        static void PrintPost(PlantStatus plantStatus)
        {
            System.Console.WriteLine("Here's how your plant felt recently:\nTemperature: {0}\nHumidity: {1}\nLuminosity: {2}\nSample date:{3}\n\n", plantStatus.Temperature, plantStatus.Humidity, plantStatus.Luminosity, plantStatus.StatusTime);
        }

    }
}