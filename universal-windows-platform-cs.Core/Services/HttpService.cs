using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace universal_windows_platform_cs.Core.Services
{
    public static class HttpService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<JObject> Post(string Url, Dictionary<string, string> values)
        {
            try
            {
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(Url, content);
                string data = await response.Content.ReadAsStringAsync();
                return JObject.Parse(data);
            } catch (Exception ex)
            {
                Debug.WriteLine($"HttpClient: {ex}");
                return null;
            }
        }

        public static async Task<JObject> Get(string Url)
        {
            try
            {
                var data = await client.GetStringAsync(Url);
                return JObject.Parse(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HttpClient: {ex}");
                return null;
            }
        }
    }
}
