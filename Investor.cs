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
            { UserID = "1201770101122278", system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };
            //{ UserID = "T400000000000025", system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };
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
        public static FJC_Vote_Investor VoteInvestore(string event_id)
        {
            List<FJC_Resolutions_Vote> FJC_Resolutions_Vote = new List<FJC_Resolutions_Vote>();
            FJC_Resolutions_Vote.Add(new FJC_Resolutions_Vote() { resolution_id = 70, in_favour = 50, not_in_favour = 50, abstain = 0 });
            FJC_Resolutions_Vote.Add(new FJC_Resolutions_Vote() { resolution_id = 71, in_favour = 50, not_in_favour = 50, abstain = 0 });
            FJC_Resolutions_Vote.Add(new FJC_Resolutions_Vote() { resolution_id = 72, in_favour = 50, not_in_favour = 50, abstain = 0 });
            FJC_Resolutions_Vote.Add(new FJC_Resolutions_Vote() { resolution_id = 73, in_favour = 50, not_in_favour = 50, abstain = 0 });
            return new FJC_Vote_Investor()
            {
                event_id = Convert.ToInt32(event_id),
                submitted=1,
                resolutions = FJC_Resolutions_Vote.ToArray()

            };
        }

        public static FJC_SpeakerRegister InvestorSpeaker(string event_id)  
        {
            return new FJC_SpeakerRegister()
            {
                event_id =Convert.ToInt32(event_id),
                email = "vikasp@bigshareonline.com"
            };
        }

        ////////////////////////////////////////////////////////////////Investor///////////////////////////////////////////////////////////////////
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            return   get_url1;
        }
        public async Task<dynamic> PostInvestorVote(FJC_Vote_Investor fJC_Vote_Investor,string token)//reset password
        {
            var get_url1 = await CommanUrl.InvestoreVoting().WithOAuthBearerToken(token).PostJsonAsync(fJC_Vote_Investor).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> PostInvestorSpeaker(FJC_SpeakerRegister fJC_SpeakerRegister, string token)//reset password
        {
            var get_url1 = await CommanUrl.Investorspeaker().WithOAuthBearerToken(token).PostJsonAsync(fJC_SpeakerRegister).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> PostForgotPassword(FJC_ForgotPassword fJC_ForgotPassword)//reset password
        {
            var get_url1 = await CommanUrl.ForgotPass().WithOAuthBearerToken(token).PostJsonAsync(fJC_ForgotPassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Post_ChangePasssword(FJC_ChangePassword fJC_ChangePassword)
        {
            var get_url1 = await CommanUrl.ChangePass().WithOAuthBearerToken(token).PostJsonAsync(fJC_ChangePassword).ReceiveString();
            return JsonConvert.DeserializeObject<ExpandoObject>(get_url1, new ExpandoObjectConverter());
        }
        public async Task<dynamic> Get_EventList(string str)
        {
            var get_url1 = await CommanUrl.EventList().WithOAuthBearerToken(token).SetQueryParam("str", str).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
        public async Task<dynamic> Get_Prifile(int aud_id)
        {
            var get_url1 = await CommanUrl.userprofile().WithOAuthBearerToken(token).SetQueryParam("aud_id", aud_id).GetJsonAsync();
            var message = get_url1.message;
            return get_url1;
        }
    }
}
