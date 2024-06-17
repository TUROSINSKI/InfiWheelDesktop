using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace InfiWheelDesktop.services
{
    class RentCarService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetUserIdFromToken(string token)
        {
            var requestContent = new
            {
                token = token
            };

            var jsonContent = JsonConvert.SerializeObject(requestContent);

            var request = new HttpRequestMessage(HttpMethod.Get, "https://infiwheel.azurewebsites.net/User/findToken");
            var requestBody = JsonConvert.SerializeObject(new { token });
            Debug.WriteLine(requestBody);
            request.Content = new StringContent(requestBody, null, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();


            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseString);
                return responseObject.id;
            }
            else
            {
                MessageBox.Show("Error retrieving user ID.");
                return null;
            }
        }

        public static async Task SaveBooking(long carId, string startdate, string enddate)
        {
            string token = TokenManager.Instance.GetToken();
            string userId = await GetUserIdFromToken(token);
            DateTime parsedstartdate = DateTime.ParseExact(startdate, "dd.MM.yyyy", null);
            DateTime paredenddate = DateTime.ParseExact(enddate, "dd.MM.yyyy", null);
            var booking = new
            {
                endDate = paredenddate.ToString("yyyy-MM-dd"),
                startDate = parsedstartdate.ToString("yyyy-MM-dd"),
                user = new
                {
                    id = userId
                },
                car = new
                {
                    id = carId
                }
            };
            var jsonContent = JsonConvert.SerializeObject(booking);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, "https://infiwheel.azurewebsites.net/Bookings/add");
            request.Headers.Add("Authorization", $"Bearer {token}");
            request.Content = httpContent;
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Booking saved successfully.");
            }
            else
            {
                MessageBox.Show("Error saving booking.");
            }
        }
    }
}
