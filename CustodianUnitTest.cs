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
using Evoting_Nunit_test;
using static Evoting_Nunit_test.CompanyUnitTest;

namespace Evoting_Nunit_test
{
 public   class CustodianUnitTest
    {
        public CustodianUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }

        Custodian _objcom = new Custodian();

        public string token { get; set; }
        public string userid { get; set; }
        public int docno { get; set; }
        public string event_id { get; set; }
        public int filedocid { get; set; }
        public string fileLocMove { get; set; }
        public class data
        {
            public int doc_no { get; set; }
            public string event_id { get; set; }
            public string remark { get; set; }
            public int doc_id { get; set; }

            public int aud_id { get; set; }
            public string UserID { get; set; }
        }

        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }

        public async Task<jsonparsingcls> Test_RTARegistration()
        {
            var check = await _objcom.Post_Registration(Custodian.Registration());
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            return jsonparsingcls1;

        }
       
        public async Task Test_RTALogin()
        {
            var check = await _objcom.Post_Login(Custodian.Default_user());
            //Assert.IsNotNull(check.Message);
            //Assert.AreEqual("User logged in succesfuly", check.Message);
            token = check.data.Token;
        }


    }
}
