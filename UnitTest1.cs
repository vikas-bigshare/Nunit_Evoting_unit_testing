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
    [TestFixture]
    public class CompanyUnitTest
    {
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
        }
        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }

        [SetUp]
        [Test,Order(1)]
        public async Task  Test_CompanyRegistration()
        {
            Company _objcom = new Company();
            var check = await _objcom.Post_Registration(Company.Registration());
             userid=check.data.UserID;
            // Assert.AreEqual("New Registration completed Successfully", check.data.Message);
        } //after login, each method will first initialise company class and assign token to it. 
        [SetUp]
        [Test,Order(2)]
        public async Task Test_CompanyLogin()
        {   
            Company _objcom = new Company();
            var check = await _objcom.Post_Login(Company.Default_user(userid));
           //Assert.IsNotNull(check.Message);
           //Assert.AreEqual("User logged in succesfuly", check.Message);
            token = check.data.Token;
        }
        [SetUp]
        [Test, Order(3)]
        public async Task Test_postdownloadagreement()
        {
            Company _objcom = new Company();
            var check = await _objcom.Post_Docdownload("tri_partiate_agreement", token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            docno = jsonparsingcls1.Data.doc_no;

            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);

        }
        [SetUp]
        [Test, Order(4)]
        public async Task Test_uploadagreement()
        {
            Company _objcom = new Company();

            var check = await _objcom.Post_DocUpload(Company.Docupload(docno),token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
            // Assert.IsNotNull(check.Message);
            // Assert.AreEqual("User logged in succesfuly", check.Message);
        }
        [SetUp]
        [Test, Order(5)]
        public async Task Test_getdownloadagreement()
        {
            Company _objcom = new Company();
            var check = await _objcom.Get_Docdownload(token);
            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);
        }
        [SetUp]
        [Test, Order(6)]
        public async Task Test_Postgenerateevent()
        {
            Company _objcom = new Company();
            var check = await _objcom.Post_GenerateEvent(Company.generate_event(),token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
             event_id = jsonparsingcls1.Data.event_id;
        }
        [SetUp]
        [Test, Order(7)]
        public async Task Test_Geteventlistcurrent()
        {
            Company _objcom = new Company();
            var check = await _objcom.Get_EventList("current", token);
            string msg = check.message;
        }
        [SetUp]
        [Test, Order(8)]
        public async Task Test_Putgenerateevent()
        {
            Company _objcom = new Company();
            var check = await _objcom.Put_Company_Eventdetails(Company.Com_event_detail(event_id), token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }
        [SetUp]
        [Test, Order(9)]
        public async Task Test_PostFileUpload()
        {
            Company _objcom = new Company();
             var check = await _objcom.Post_FileUpload(token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
             filedocid = jsonparsingcls1.Data.doc_id;
        }


        ////[SetUp]
        ////[Test, Order(10)]
        ////public async Task Test_postROMupload()
        ////{
        ////    Company _objcom = new Company();
        ////    var check = await _objcom.Post_Rom_Upload(Company.romupload(event_id, filedocid), token);
        ////    // string msg = check.message;
        ////}

        [SetUp]
        [Test, Order(10)]
        public void romuploadfile_eventid_change()
        {
            string filepath = "C:\\Evoting-Github\\Files\\CDSLForTest.txt";
            string Romfile = "C:\\Evoting-Github\\Rom_uploadedFiles\\";
            using (StreamReader sr = new System.IO.StreamReader(filepath))
            {
                //string eventid = "5555";
                string changefirstline;
                string firstline;
                //string fileLocMove = "";
                string newpath = Path.GetDirectoryName(Romfile);
                fileLocMove = newpath + "\\" + System.DateTime.Now.ToString("yyyyMMdd-hhmmssfff") + "CDSLFor" + event_id + ".txt";
                string text = File.ReadAllText(filepath);
                string[] lines = File.ReadAllLines(filepath);
                firstline = lines[0];
                changefirstline = firstline.Substring(0, firstline.IndexOf("~"));
                text = text.Replace(changefirstline, "00=" + event_id);
                string default_path = fileLocMove;
                if (!File.Exists(default_path))
                {
                    FileStream fs = File.Create(default_path);
                    fs.Flush();
                    fs.Close();
                }
                File.WriteAllText(fileLocMove, text);
                //
               
            }
        }
        [SetUp]
        [Test, Order(11)]
        public async Task Test_PostNewgeneratedFileUpload()
        {
            Company _objcom = new Company();
            var check = await _objcom.Post_FileUploadnew(token, fileLocMove);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            filedocid = jsonparsingcls1.Data.doc_id;
        }
        [SetUp]
        [Test, Order(12)]
        public async Task Test_postApprovedEvent()
        {
            Company _objcom = new Company();
            var check = await _objcom.PostApproved_Event(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.Data.remark;
        }
        [SetUp]
        [Test, Order(13)]
        public async Task Test_Geteventlistapproved()
        {
            Company _objcom = new Company();
            var check = await _objcom.Get_EventList("approved", token);
            Assert.AreEqual(200, check.statusCode);
            //jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            //jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            //string msg = jsonparsingcls1.message;
        }
    }
}