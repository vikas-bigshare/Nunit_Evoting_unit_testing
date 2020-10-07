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
   //[TestFixture]
   public class ScrutinizerUnitTest
    {
        public ScrutinizerUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }
        
        Scrutinizer _objcom = new Scrutinizer();
        public string token { get; set; }
        public string userid { get; set; }
        public string event_id { get; set; }
        public int docno { get; set; }
        public int rowid { get; set; }
        
        public int filedocid { get; set; }
        public string fileLocMove { get; set; }
        public class data
        {
            public int doc_no { get; set; }
            public string event_id { get; set; }
            public string remark { get; set; }
            public int doc_id { get; set; }
            public int rowid { get; set; }

            public string UserID { get; set; }
        }
        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }


        //[SetUp]
        //[Test, Order(1)]
        public async Task<jsonparsingcls> Test_ScrutRegistration()
        {
           
            var check = await _objcom.Post_Registration(Scrutinizer.Registration());
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            return jsonparsingcls1;
            // Assert.AreEqual("New Registration completed Successfully", check.data.Message);
        } 
        //[SetUp]
        //[Test, Order(2)]
        public async Task Test_ScrutLogin(string scrut_UserId)
        {
            var check = await _objcom.Post_Login(Scrutinizer.Default_user(scrut_UserId));
            //Assert.IsNotNull(check.Message);
            //Assert.AreEqual("User logged in succesfuly", check.Message);
            token = check.data.Token;
        }

        //[SetUp]
        //[Test, Order(3)]
        public async Task Test_postdownloadagreement()
        {
            var check = await _objcom.Post_Docdownload("tri_partiate_agreement", token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            docno = jsonparsingcls1.Data.doc_no;

            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);

        }
        //[SetUp]
        //[Test, Order(4)]
        public async Task Test_uploadagreement()
        {
            var check = await _objcom.Post_DocUpload(Company.Docupload(docno), token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
            // Assert.IsNotNull(check.Message);
            // Assert.AreEqual("User logged in succesfuly", check.Message);
        }
        //[SetUp]
        //[Test, Order(5)]
        public async Task Test_getdownloadagreement()
        {
            var check = await _objcom.Get_Docdownload(token);
            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);
        }

        //[SetUp]
        //[Test, Order(6)]
        public async Task Test_PostScrutVotingRestrict()
        {
            var check = await _objcom.Post_ScrutRestrict(Scrutinizer.scrutrestrict(event_id),token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }


        //[SetUp]
        //[Test, Order(7)]
        public async Task Post_UnblockEvent()
        {
            var check = await _objcom.Post_UnblockEvent(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }

        //[SetUp]
        //[Test, Order(8)]
        public async Task Post_finalizeevent()
        {
            var check = await _objcom.Post_finalizeevent(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }

        //[SetUp]
        //[Test, Order(9)]
        public async Task Get_reportsgeneration()
        {
            var check = await _objcom.Get_reportsgeneration(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }
        
    }
}
