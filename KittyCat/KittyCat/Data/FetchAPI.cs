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
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6ImQ0NWRkZjRjYWVlNDljZmI3ODVkNmIxNDhjMGE3YzFmOTQ0YzFkNDg2Y2FiMGRkMTk4MmY1MWU1MWQwN2Y0ODdmOTQ0ZjFhYWFlMWQ1ODQ0IiwiaWF0IjoxNjI0MDIxODgzLCJuYmYiOjE2MjQwMjE4ODMsImV4cCI6MTYyNDAyNTQ4Mywic3ViIjoiIiwic2NvcGVzIjpbXX0.WMQT-6kDknEXjgljZ5geWl8ShOizZEi9wYaeMneMJqIHVoaB4c_jd-oywX2Z3sAoLzjJGwJMUWOYMhvfcFCyLjZa7CklIUy6qL5vcjEQCPRDC5anWxRugeVwpNU739NGAK7ASX_AlDnktNy3pzOl3lnwVyTDe-rAysiPumnlafDUoXL8FukC0pLU-Ds8_gooDWaZGz1xaMf-eL7Q4qlB2lY9NNrG3OEzddYfzT0G9_OmZkrRpo7TsID7FfFwl2l2umrLDuvnRaVEdiNqPGQ9CeAE3FUMogQqZh8iS5zzJ06o-_P3d65Mk06ny90iDhQvNmhQtgB5J0tMKaBPCZ7NZw");

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
