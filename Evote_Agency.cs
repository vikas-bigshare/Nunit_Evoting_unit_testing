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
    public class Evote_Agency
    {
        public string token { get; set; }
        public static FJC_LoginRequest Default_user()
        {
            return new FJC_LoginRequest()
            { UserID = "A700000000000001", system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };
        }
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_AccountList(string token)
        {
            var get_url1 = await CommanUrl.AccountList().WithOAuthBearerToken(token).SetQueryParam("user_type", 1).GetJsonAsync();
            return get_url1;
        }
        public async Task<dynamic> Post_EvoteAgencyLock(string token,int event_id)
        {
            var get_url1 = await CommanUrl.EvoteAgencyLock().WithOAuthBearerToken(token).SetQueryParam("event_id", event_id).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_EvoteAgencyUnlock(string token,int event_id)
        {
            var get_url1 = await CommanUrl.EvoteAgencyUnLock().WithOAuthBearerToken(token).SetQueryParam("event_id", event_id).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_AccountProfile(string token)
        {
            var get_url1 = await CommanUrl.GetAccount().WithOAuthBearerToken(token).SetQueryParam("aud_id", 13).GetJsonAsync();
            return get_url1;
        }
        public async Task<dynamic> Post_AccountVerify(string token)
        {
            var get_url1 = await CommanUrl.Accountverify().WithOAuthBearerToken(token).SetQueryParam("aud_id", 13).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_Accountsearch(string token)
        {
            var get_url1 = await CommanUrl.Accountsearch().WithOAuthBearerToken(token).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
    }
}
