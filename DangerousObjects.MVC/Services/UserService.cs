using System.Net.Http.Headers;
using System.Text;
using DangerousObjects.MVC.Helpers;
using DangerousObjects.MVC.Helpers.Constants;
using DangerousObjects.MVC.Helpers.DTOs;
using DangerousObjects.MVC.Helpers.Enums;
using DangerousObjects.MVC.Models;
using DangerousObjects.MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace DangerousObjects.MVC.Services;

public class UserService : IUserService
{
    public async Task<GetUnverifiedUsersResultDto> GetUnverifiedUsers(string token)
    {
        string apiUrl = Routes.MainApiLink + Routes.AdminUserList;
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                List<FullUserModel> userList = JsonConvert.DeserializeObject<List<FullUserModel>>(jsonContent);

                if (userList != null)
                {
                    foreach (var item in userList)
                    {
                        item.Token = token;
                    }
                }

                return new GetUnverifiedUsersResultDto
                {
                    ResponseResult = ResponseResultEnum.Ok,
                    FullUserModels = userList
                };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                return new GetUnverifiedUsersResultDto
                {
                    ResponseResult = ResponseResultEnum.WrongRole
                };
            }
            else
            {
                return null;
            }
        }
    }

    public async Task<bool> VerifyUser(int id, string token)
    {
        string apiUrl = Routes.MainApiLink + Routes.VerifyUser + id;
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsync(apiUrl, null);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public async Task<FullUserModel?> GetUserProfile(string token)
    {
        string apiUrl = Routes.MainApiLink + Routes.UserProfile;
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                FullUserModel userModel = JsonConvert.DeserializeObject<FullUserModel>(jsonContent);
                userModel.Token = token;
                return userModel;
            }
            
            return null;
            
        }
    }
    
    public async Task<List<DangerousObjectModel>> GetDangerousObjects(string token)
    {
        string apiUrl = Routes.MainApiLink + Routes.DangerousObjectList;
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                List<DangerousObjectModel> dangerObjList = JsonConvert.DeserializeObject<List<DangerousObjectModel>>(jsonContent);
                
                
                if (dangerObjList != null)
                {
                    foreach (var item in dangerObjList)
                    {
                        item.Token = token;
                    }

                    return dangerObjList;
                }
            }

            return new List<DangerousObjectModel>();
        }
    }
    
    public async Task<bool> AddDangerousObject(DangerousObjectModel model)
    {
        string apiUrl = Routes.MainApiLink + Routes.AddDangerousObject;
        string jsonBody = JsonConvert.SerializeObject(model);
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.Token);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public async Task<List<MessageModel>> GetMessages(string token)
    {
        string apiUrl = Routes.MainApiLink + Routes.MessageList;
        
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                List<MessageModel> messageList = JsonConvert.DeserializeObject<List<MessageModel>>(jsonContent);
                
                
                if (messageList != null)
                {
                    foreach (var item in messageList)
                    {
                        item.Token = token;
                    }

                    return messageList;
                }
            }

            return new List<MessageModel>();
        }
    }

    public async Task<bool> AddMessage(MessageModel model)
    {
        string apiUrl = Routes.MainApiLink + Routes.AddMessage;
        string jsonBody = JsonConvert.SerializeObject(model);

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.Token);
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}