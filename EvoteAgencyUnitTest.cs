using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using evoting.Domain.Models;
using System.Collections.Generic;
using System;
using evoting;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using System.Threading;

namespace Evoting_Nunit_test
{
  public  class EvoteAgencyUnitTest
    {
        public EvoteAgencyUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }

        Evote_Agency _objcom = new Evote_Agency();
        public string token { get; set; }
        public string userid { get; set; }
        public string event_id { get; set; }
        
       
        public async Task Test_EvotAgencyLogin()
        {
            var check = await _objcom.Post_Login(Evote_Agency.Default_user());
            EvoteAgency_Module.EvoteAgency_Login.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_Login.Root>(check);
            Assert.AreEqual("User logged in succesfully", someval.message);
            token = someval.data.Token;
        }
        public async Task Test_AccountList()
        {
            var check = await _objcom.Get_AccountList(token);
            EvoteAgency_Module.EvoteAgency_AccountList.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_AccountList.Root>(check);
        }
        public async Task Test_AccountLock()
        {
            var check = await _objcom.Post_EvoteAgencyLock(token, Convert.ToInt32(event_id));
            EvoteAgency_Module.EvoteAgency_LockUnlock.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_LockUnlock.Root>(check);
        }
        public async Task Test_AccountUnlock()
        {
            var check = await _objcom.Post_EvoteAgencyUnlock(token, Convert.ToInt32(event_id));
            EvoteAgency_Module.EvoteAgency_LockUnlock.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_LockUnlock.Root>(check);
        }
          public async Task Test_GetAccount()
        {
            var check = await _objcom.Get_AccountProfile(token);
            EvoteAgency_Module.EvoteAgency_GetAccount.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_GetAccount.Root>(check);
        }
        public async Task Test_PostAccountVerify()
        {
            var check = await _objcom.Post_AccountVerify(token);
            EvoteAgency_Module.EvoteAgency_AccountVerify.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_AccountVerify.Root>(check);
        }
        public async Task Test_PostAccountSearch()
        {
            var check = await _objcom.Post_Accountsearch(token);
            EvoteAgency_Module.EvoteAgency_AccountSearch.Root someval = JsonConvert.DeserializeObject<EvoteAgency_Module.EvoteAgency_AccountSearch.Root>(check);
        }
    }
}
