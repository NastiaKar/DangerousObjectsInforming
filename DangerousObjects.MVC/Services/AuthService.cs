using System.Text;
using DangerousObjects.MVC.Helpers;
using DangerousObjects.MVC.Helpers.DTOs;
using DangerousObjects.MVC.Models;
using DangerousObjects.MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace DangerousObjects.MVC.Services;

public class AuthService : IAuthService
{
    public async Task<AuthResultDto> GetUserByLogin(UserLoginModel request)
    {
        string apiUrl = Routes.MainApiLink + Routes.AuthLogin;
        string jsonBody = JsonConvert.SerializeObject(request);
        using (HttpClient client = new HttpClient())
        {
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);
            
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return new AuthResultDto
                {
                    IsSuccess = true,
                    Response = responseString
                };
            }
            else
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return new AuthResultDto
                {
                    IsSuccess = false,
                    Response = responseString
                };
            }
        }
    }
}