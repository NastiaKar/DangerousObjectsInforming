using System.Text;
using DangerousObjects.MVC.Helpers;
using DangerousObjects.MVC.Models;
using DangerousObjects.MVC.Services.Interfaces;
using DangerousObjectsCommon.Auth;
using Newtonsoft.Json;

namespace DangerousObjects.MVC.Services;

public class AuthService : IAuthService
{
    public async Task<AuthResult> GetUserByLogin(UserLoginModel request)
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
                AuthResult result = JsonConvert.DeserializeObject<AuthResult>(responseString);
                return result;
            }
            else
            {
                return new AuthResult
                {
                    Success = false,
                    Errors = new List<string> { "Invalid login attempt." }
                };
            }
        }
    }
}