using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dpark.Models.WebService
{
    public class Client
    {
        private const string RequestSpaces = @"allspaces.json";

        async private Task<string> Get(string request)
        {
            #if DEBUG
            var client = new HttpClient { BaseAddress = new Uri(Config.ServerAddress) };
            #else
            var client = new HttpClient { BaseAddress = new Uri(Config.ServerAddress), Timeout = new TimeSpan(0, 0, 10)};
            #endif

            var response = await client.GetAsync(request);

            return response.Content.ReadAsStringAsync().Result;
        }

        async public Task<bool> GetSpaces()
        {
            bool isSuccess = false;

            try
            {
                //clear data if exist
                var token = await Get(RequestSpaces);
                var list = JsonConvert.DeserializeObject<List<Object>>(token);

                foreach(var item in list)
                {
                    var deserializePost = JsonConvert.DeserializeObject<DeserializePost>(item.ToString());
                    AppData appData = new AppData(deserializePost);
                    //for debugging
                    Debug.WriteLine(deserializePost);
                }                
            }
            catch (Exception ex)
            {
                isSuccess = false;
                Debug.WriteLine(ex);
            }

            return isSuccess;
        }
    }
}
