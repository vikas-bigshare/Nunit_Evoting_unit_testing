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

namespace Evoting_Nunit_test
{
  public  class InvestorUnitTest
    {
        public InvestorUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }
        Investor _objcom = new Investor();
        public string token { get; set; }
        public string userid { get; set; }
        public string event_id { get; set; }
        public int docno { get; set; }
        public int filedocid { get; set; }
        public string fileLocMove { get; set; }
        
        public async Task Test_InvestorLogin()
        {
            var check = await _objcom.Post_Login(Investor.Default_user());
            Investor_Modules.Investor_Login.Root someval = JsonConvert.DeserializeObject<Investor_Modules.Investor_Login.Root>(check);
            token = someval.data.Token;
            Assert.AreEqual("User logged in succesfuly", someval.message);
        }
        public async Task Post_InvestorVoting()
        {
            var check = await _objcom.PostInvestorVote(Investor.VoteInvestore(event_id), token);
            Investor_Modules.Investorvote.Root someval = JsonConvert.DeserializeObject<Investor_Modules.Investorvote.Root>(check);
            Assert.IsNotNull(someval.data.REMARK);
        }
    }
}
