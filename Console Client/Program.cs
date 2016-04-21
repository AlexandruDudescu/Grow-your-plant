using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SocialNetwork.Console
{
    class Program
    {
        static void Main()
        {
            RunAsync().Wait();
            System.Console.ReadLine();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:26315");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Posts/GetPosts");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<plantStatus>>(data);
                    foreach (var post in posts)
                        PrintPost(post);
                }
            }

            var hubConnection = new HubConnection("http://localhost:26315");
            var hub = hubConnection.CreateHubProxy("PostHub");

            hub.On<Post>("publishPost", (post) => PrintPost(post));
            hubConnection.Start().Wait();
        }

        static void PrintPost(Post post)
        {
            System.Console.WriteLine("{0}: {1}", post.UserName, post.Text);
        }
    }
}