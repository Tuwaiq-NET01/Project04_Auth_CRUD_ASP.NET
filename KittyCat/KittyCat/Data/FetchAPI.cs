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
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiJ4Y2phZTZSVmVkMU9xTUs2V3NXMmpjOWtFSVJaR0ZRWG8xWnlHQ2FMWjFVZ2h6bUNvdiIsImp0aSI6ImY4N2ViODBkZWNjODgyZTI3YmRjZWQwMDY1ZTQ1ZjQ4YjczZjdjZmMyYjFiNzFlMGNhNjMxMDM3NWZhMWE0N2RhOGJlNzZlMWI4NDkyZWFhIiwiaWF0IjoxNjIzODU1NjU5LCJuYmYiOjE2MjM4NTU2NTksImV4cCI6MTYyMzg1OTI1OSwic3ViIjoiIiwic2NvcGVzIjpbXX0.rmvn8BvhxE79IRwJafdzXBvMSCn5_5Ehecv5Xg2L3Fl98its7pcfNLtQtXTW1zjzBIjNyYW_dbIaGbtpY9KdjrXfUVOJX7n_6wBbnxgdWcWoOkWTBFj7qi4tqdDmFBCHjdVvGxA73MBPYQzOcflFWsdY21ZbrJd_A6lWIvzhUEJO7_jWgW8rgw8Kh81AzHIdEOpl5po9dxA_Z9VC9l-k979eRqa1YSlyNPd8RyyHZ5Wz3b1yDb-MtTvoQJFhoe8lrurcdm-4WyxxcvWw3aRMo_NUVNMnqII74hI9HILP90Dh_nqjkbvnkqCmvUYHlvP_o7Zuov07QFd-F8yHu4It8g");

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
