using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KittyCat.Data
{
    public class FetchAPI
    {
        public static string httpReq()
        {

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.petfinder.com/v2/animals?type=Cat&limit=90"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6IjYyZWU4YTRmMzYzZGFlYTQwMzk5MWIxOGIxOWI3YmQ3ZDY4Yzc1YzMzZTM1ZTBmMWIzZjM3Y2M1NmY4Y2U4NDViOTE0MjhkZDcyYmE5ZjdjIiwiaWF0IjoxNjI0MDQwMTE0LCJuYmYiOjE2MjQwNDAxMTQsImV4cCI6MTYyNDA0MzcxNCwic3ViIjoiIiwic2NvcGVzIjpbXX0.Rc-jBLcFiXYUYYrQjMXX8HqcUcEThmvzqGY-DOnsQ8xdIdjMIxNwLAfTEVpO4kk6MMuszcyY6-aQwV6Vudn7KJqWxj1QZSnJEFPOiSS8BaAUPCSqDp5QtO4c-eP38sfyLRoW1m9p1nliq3zHusgPaNU2lK1OlosdPwncPlIVW6sppcX01tqVoDqzpq4lW2NPRy9I9mQAjh0Six4DDxv2WQ18WSbQ7pbirK89NRZaQ-uTw65wrroD6jqKTZqwpL0r-PgJ71_loLGoFwgcYoc1HH-VlRg4TU2WPzpxFA1k4eigf_CR3xIVI-LIGc2OQngm5kEI680cPCvxpO5GV2DdOQ");

                    var response = httpClient.Send(request);
                    string resTest = response.Content.ReadAsStringAsync().Result;
                    return resTest;
                
                }
            }


            /*            using (var client = new HttpClient())
                        {
                            var uri = new Uri(api);
                            client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6IjA4NGE3NTYyYWYxY2M1ZTg1MmZiOTFkMDJkNjg5YzMwNThjNzE4YzJhZGNjY2EzN2UyOWM3ZjdkMTFkNzRlZDc2Yzk5MjRiMzg2OTE3NDViIiwiaWF0IjoxNjIzNzA0NTc3LCJuYmYiOjE2MjM3MDQ1NzcsImV4cCI6MTYyMzcwODE3Nywic3ViIjoiIiwic2NvcGVzIjpbXX0.UPWwQXsY6c3jj73cVqGHIPoOqL5HhbfP-UrZUpBoMMZDpyQkexFjNHGO4IViB1XqZTlfcvEAV5rXJttLRnwctKfmOhsost8R1d3NWIJtUkiyy4oLO9YBD3hxGOmuUDmFAIkS8kB1NJ2Yqpc3Fbjpi42EgouXRqVP4JMB2Kj8jEUoJNZVcXG0Rn5ILDGelIJ_xF01rI6fdcLqTAcYaZ_0wOef_U4cE-FAxInu6-hQzZCdCOah4y6cPhPTVh7_Bg3oquyyxUYmxF4C-CnB_Fipvfq27_bJucuXj8jewd_7XfdiF8Y1z5BXmCJwOpRfOiEyKPu2lOoF1PrTJkUtp7kEEw");
                            var resonse = client.GetAsync(uri);
                            Console.WriteLine("-------------------------------------------------------");

                            // ... 
                            Console.WriteLine("-------------------------------------------------------");
                            resonse.Wait();
                            string res = resonse.Result.Content.ReadAsStringAsync().Result;

                            return res;
                        }*/
        }
    }
}
