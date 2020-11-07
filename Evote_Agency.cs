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
            { UserID = "T400000000000025", system_ip = "127.0.0.1", encrypt_Password = "bigshare@123" };
        }

        public static FJC_AccountSearch Account_Search()
        {
            return new FJC_AccountSearch()
            { user_type = 3, str = "ad" };
        }

        //public static FJC_Intimation intimation()
        //{
        //    return new FJC_Intimation()
        //    { event_id = 60187, event_name = "60187-Tirupati Starch & Chemicals LTD", notice_date="2020-11-02", rom_file="C:/evoting/", email_sent_date="2020-11-02", post_sent_date="2020-11-01" };
        //}
        public async Task<dynamic> Post_Login(FJC_LoginRequest _fjc_login)
        {
            var get_url1 = await CommanUrl.Login().PostJsonAsync(_fjc_login).ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Get_AccountList(string token)
        {
            var get_url1 = await CommanUrl.AccountList().WithOAuthBearerToken(token).SetQueryParam("user_type", 1).GetStringAsync();
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
            var get_url1 = await CommanUrl.GetAccount().WithOAuthBearerToken(token).SetQueryParam("aud_id", 13).GetStringAsync();
            return get_url1;
        }
        public async Task<dynamic> Post_AccountVerify(string token)
        {
            var get_url1 = await CommanUrl.Accountverify().WithOAuthBearerToken(token).SetQueryParam("aud_id", 13).PostJsonAsync("").ReceiveString();
            return get_url1;
        }
        public async Task<dynamic> Post_Accountsearch(FJC_AccountSearch fJC_AccountSearch ,string token)
        {
            var get_url1 = await CommanUrl.Accountsearch().WithOAuthBearerToken(token).PostJsonAsync(fJC_AccountSearch).ReceiveString();
            return get_url1;
        }

        //public async Task<dynamic> Post_intimation(FJC_Intimation fJC_Intimation, string token)
        //{
        //    var get_url1 = await CommanUrl.Accountsearch().WithOAuthBearerToken(token).PostJsonAsync(fJC_Intimation).ReceiveString();
        //    return get_url1;
        //}
    }
}
