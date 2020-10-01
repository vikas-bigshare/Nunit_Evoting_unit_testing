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
        public class data
        {
            public int doc_no { get; set; }
            public string event_id { get; set; }
            public string remark { get; set; }
            public int doc_id { get; set; }
        }
        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }

        [SetUp]
        [Test, Order(1)]
        public async Task Test_InvestorLogin()
        {
            var check = await _objcom.Post_Login(Investor.Default_user());
            //Assert.IsNotNull(check.Message);
            //Assert.AreEqual("User logged in succesfuly", check.Message);
            token = check.data.Token;
        }

        [SetUp]
        [Test, Order(2)]
        public async Task Post_InvestorVoting()
        {
            var check = await _objcom.PostInvestorVote(Investor.VoteInvestore(event_id), token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }
    }
}
