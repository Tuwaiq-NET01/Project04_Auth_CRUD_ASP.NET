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
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6IjA5MmUxZWYyYzU2ZGViZjc4NWJjZThkNDYxMTU0OTNkMDE3MTlhNzhlZmRhYmFiYjc3NmM1YzM2OWM2Y2MxYWVjYmEzY2ZmN2UyNDc3NWM1IiwiaWF0IjoxNjIzODQ1NjY2LCJuYmYiOjE2MjM4NDU2NjYsImV4cCI6MTYyMzg0OTI2Niwic3ViIjoiIiwic2NvcGVzIjpbXX0.HPVdTpAUeHAAqYsEh6y126uJzrWK2h-ZvL3GKt7tXiUut_fWQqa8v5Q9Z49ApAv1C5-gQqzjVCxm2n9rV7Pvxqmh8yzSPFzZ_pP4DiI3azRsQ834s1tg6tRy5nRfEbT4ZX2MGrd9QIQ25CQhdDZEgO5iNNC5r5HHD2qfahBBqvPEX-_2jIvxcHba300qybkTjCyiUPch8UZ5JkfUWFfynwitzqGqXQ2VSSylz1CiuJhwp8nqjWRde5G9rBn8Bi_2shZM0BmBX_CtznL3Q1rMKOXLU3NPLGV9X_859HHMg96tZbpJ0mQpX_9tDzdQqUpsT2zzLTzLTuPUCwSo68zXwA");

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
