using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using evoting;
using System.Net.Http;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using evoting.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;

namespace Evoting_Nunit_test
{
  public  class Investor
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user()
        {
            return new FJC_LoginRequest()
            { UserID = "IN20111113699631", system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };

        }
        public static FJC_ForgotPassword forgot_password()   //reset password
        {
            return new FJC_ForgotPassword()
            {
                UserID = "IN20111113699631",
                EmailID = "priyesh@bigshareonline.com",
                PAN_ID = "XXXXXXXXXX"
            };
        }
        public static FJC_ChangePassword change_password()
        {
            return new FJC_ChangePassword()
            {
                UserID = "IN20111113699631",
                encrypt_OldPassword = "bigshare@12",
                encrypt_NewPassword = "bigshare@123"
            };
        }
      
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            dynamic _obj = JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
            token = _obj.data.Token;
            return _obj;
        }
        public async Task<dynamic> PostForgotPassword(FJC_ForgotPassword fJC_ForgotPassword)//reset password
        {
            var get_url1 = await CommanUrl.ForgotPass().WithHeader("Token", token).PostJsonAsync(fJC_ForgotPassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithHeader("Token", token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Get_EventList(string str)
        {
            var get_url1 = await CommanUrl.EventList().WithHeader("Token", token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Get_Prifile(int aud_id)
        {
            var get_url1 = await CommanUrl.userprofile().WithHeader("Token", token).SetQueryParam("aud_id", aud_id).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
    }
}
