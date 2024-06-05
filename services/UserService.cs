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
using Newtonsoft.Json.Linq;

namespace InfiWheelDesktop.services
{
    class UserService
    {

        private static readonly HttpClient client = new HttpClient();

        public static async Task<bool> SignUp(UserModel userModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(userModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://infiwheel.azurewebsites.net/User/register", content);
                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                return false;
            }
        } 

        public static async Task<LoginResponse> Login(UserModel userModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(userModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://infiwheel.azurewebsites.net/User/authenticate", content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<JObject>(responseContent);

                string token = responseObject["token"]?.ToString();
                bool success = response.IsSuccessStatusCode;

                return new LoginResponse
                {
                    Success = success,
                    Token = token
                };
            }
            catch
            {
                return new LoginResponse
                {
                    Success = false,
                    Token = null
                };
            }
        }
    }
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
