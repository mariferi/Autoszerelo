using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi_Common.Models;

namespace Munkafelvevo.DataProviders
{
    internal class DataProvider
    {
        private const string _url = "http://localhost:5555/api/servicesheet";

        public static IEnumerable<ServiceSheet> GetServiceSheets()//all service sheets
        {
            using(var client =new HttpClient())
            {
                var response=client.GetAsync(_url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var rawData=response.Content.ReadAsStringAsync().Result;
                    var ServiceSheets =JsonConvert.DeserializeObject<IEnumerable<ServiceSheet>>(rawData);
                    return ServiceSheets;
                }
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateSheet(ServiceSheet serviceSheet)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(serviceSheet);
                var content =new StringContent(rawData,Encoding.UTF8,"application/json");

                var response = client.PostAsync(_url, content).Result;
                if (response.IsSuccessStatusCode)
                { 
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
               
            }
        }

        public static void UpdateSheet(ServiceSheet serviceSheet)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(serviceSheet);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PutAsync(_url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }

        public static void DeleteSheet(ServiceSheet serviceSheet)
        {
            using (var client = new HttpClient())
            {
                var Id = serviceSheet.Id;

                var response = client.DeleteAsync($"{_url}/{Id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }

            }
        }
    }
}
