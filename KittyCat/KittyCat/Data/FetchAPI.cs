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
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6IjQ2NzZkODBhNjdmY2YxMzAxZmU1NGE5Y2UxNjZmZTY3OWJhZmYzZGQwMmViN2Y5YTdmNmFmYjNjMTIyNzQ1ZTgyMTdjMjUyNGRlODM4ODhmIiwiaWF0IjoxNjIzODY0MTY2LCJuYmYiOjE2MjM4NjQxNjYsImV4cCI6MTYyMzg2Nzc2Niwic3ViIjoiIiwic2NvcGVzIjpbXX0.hzfPoEzC7RNo8V6Pi83J0moh4tmGZ-QgQ-Hg6hquIvTQLLcXzr7hCxu1zP-peRFDmktcADZ8gl7d_qLE0lUQ8kT0AK06qmCri6gjOyT6CxtTJMucluVlo25B6PXltQ2ZhQXzMdbayBmZpsEmPJGDh6IJV7wJS6H4MDDMyRCcBjPsEUlH4oH84OD2vp-nXoPsgD9uQJLRGrHMGqPJ6RDMOMTQHc1sUMQDwuTmlD0A9lznoKiVQi4Ufp0NeXkm8cVaWMLGNrsLA7TJFq88Z0sC38c2dGTcatMcm6hsBUAwSDZc-QH0OVh3OdvFLq8TKy3eEGiq20SAzqJpMzcd_J0gIA");

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
