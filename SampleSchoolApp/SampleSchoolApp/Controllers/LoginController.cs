using Newtonsoft.Json;
using SampleSchoolApp.AppConstants;
using SampleSchoolApp.Helpers.Interfaces;
using SampleSchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleSchoolApp.Controllers
{
    public class LoginController
    {
        public async Task<bool> CheckLoginDetails(string userName, string password, bool rememberMe)
        {
           string url = Constants.LoginUrl;
            LoginModel loginrecord = new LoginModel();
            loginrecord.Username = userName;
            loginrecord.Password = password;
            loginrecord.RememberMe = rememberMe;
            if (rememberMe == true)
            {
                IFileReadWrite fileReadWrite = Xamarin.Forms.DependencyService.Get<IFileReadWrite>();
                string serialized = JsonConvert.SerializeObject(loginrecord);
                bool x = await fileReadWrite.WriteToFile(serialized);
            }
            else
            {
                IFileReadWrite fileReadWrite = Xamarin.Forms.DependencyService.Get<IFileReadWrite>();
                fileReadWrite = null;
            }
               return await UserLoginAPICall(url, loginrecord, rememberMe);
        }

        public async Task<bool> UserLoginAPICall(string url, LoginModel loginrecord, bool rememberMe)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var json = JsonConvert.SerializeObject(loginrecord);

                using (var client = new HttpClient())
                {
                    response = new HttpResponseMessage();
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
    }
}
