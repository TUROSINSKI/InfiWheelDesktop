using InfiWheelDesktop.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Net.Http.Headers;

namespace InfiWheelDesktop.services
{
    class CarService
    {
        private static readonly HttpClient client = new HttpClient();
        

        public static async Task<List<CarModel>> GetCarsAsync()
        {
            try
            {
                string token = TokenManager.Instance.GetToken();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync("https://infiwheel.azurewebsites.net/Car/all");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CarModel>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                return new List<CarModel>();
            }
        }
    }
}
