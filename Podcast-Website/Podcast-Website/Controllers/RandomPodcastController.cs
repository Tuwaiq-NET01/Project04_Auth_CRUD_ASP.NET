using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Podcast_Website.Models;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;

namespace Podcast_Website.Controllers
{
    public class RandomPodcastController : Controller
    {
        public string getaListfromAPI()
        {
            //var client = new HttpClient();
            //var RequestUri = new Uri(url);
            //var response = client.GetAsync(RequestUri);
            //response.Wait();
            //var result = response.Result.Content.ReadAsStringAsync();
            //Console.WriteLine(result.Result);
            ////Root v = JsonSerializer.Deserialize<Root>(result.Result);
            //return null;// v;

            string apiKey = "VMVXWJJG6AW8XZKT65WQ";
            string apiSecret = "TE35WWjLJG8VRNFugb5ZRF6FhXeD8KWKYDMqVn7$";
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int apiHeaderTime = (int)t.TotalSeconds;

            //Hash them to get the Authorization token
            string hash = "";
            
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hashed = sha1.ComputeHash(Encoding.UTF8.GetBytes(apiKey + apiSecret + apiHeaderTime));
                var sb = new StringBuilder(hashed.Length * 2);

                foreach (byte b in hashed)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                hash = sb.ToString();
                
            }

            //Create the web request and add the required headers
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.podcastindex.org/api/1.0/search/byperson?q=Klaus+Schwab&pretty");
          /*  not working in mono: request.Headers.Add("User-Agent", "SuperPodcastPlayer/1.8");*/
            request.UserAgent = "SuperPodcastPlayer/1.8";
            request.Headers.Add("X-Auth-Date", apiHeaderTime.ToString());
            request.Headers.Add("X-Auth-Key", apiKey);
            request.Headers.Add("Authorization", hash);
           
            //Send the request and collect/show the results
            try
            {
                WebResponse webResponse2 = request.GetResponse();
                Stream stream2 = webResponse2.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);

               

                return reader2.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error.");
                Console.Write(e.Message); // to remove compiler warning and to show error message
                return "null";
            }
        }
    



        public IActionResult Index()
        {
            Console.WriteLine("Hi");
            // Console.WriteLine(getaListfromAPI(BASE_URL).items[2].title);
            var dataString = getaListfromAPI();
            ViewData["dataString"] = dataString;
            return View();
        }


    }
}
