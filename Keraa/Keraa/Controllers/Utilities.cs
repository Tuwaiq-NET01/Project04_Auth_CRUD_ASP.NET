using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


namespace Keraa.Controllers
{
    public class Utilities
    {

        public static async Task<List<string>> GetCurrentCoordinates()
        {
            string token = ""; //needs to be store in .env
            string url = "https://www.googleapis.com/geolocation/v1/geolocate?key="+token;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    request.Content = new StringContent("{\"@your_filename.json\": \"\"}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                    dynamic CurrentCoordinates = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    // List<string> returnedCoordinates = new() { CurrentCoordinates.location.lat , CurrentCoordinates.location.lng };
                    List<string> returnedCoordinates = new List<string>();
                    returnedCoordinates.Add((string)CurrentCoordinates.location.lat);
                    returnedCoordinates.Add((string)CurrentCoordinates.location.lng);
                    return returnedCoordinates;
                }
            }
        }





    }
}
