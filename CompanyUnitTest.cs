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
 
    public class CompanyUnitTest
    {
        Company _objcom = new Company();
       
        public string token { get; set; }
        public string userid { get; set; }
        public string RTAUserId { get; set; }
        public int RTAAudId { get; set; }
        public string scrut_UserId { get; set; }
        public int scrut_rowid{ get; set; }
        public string Cust_UserId { get; set; }
        public int Cust_rowid { get; set; }
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
            public int rowid { get; set; }

            public int aud_id { get; set; }
            public string UserID { get; set; }
        }
        public class jsonparsingcls
        {
            public string statusCode { get; set; }
            public string message { get; set; }
            public data Data { get; set; }

        }
        public async Task callRTA()
        {
            RTAUnitTest rTAUnitTestr = new RTAUnitTest(event_id);
            RTA_Module.RTA_Registration.Root rvalue = await rTAUnitTestr.Test_RTARegistration();
            RTAUserId = rvalue.data.UserID;
            RTAAudId = rvalue.data.aud_id;
        }
        public async Task callScrutinizer()
        {
            ScrutinizerUnitTest scrutinizerUnits = new ScrutinizerUnitTest(event_id);
            Scrutinizer_Module.Scrutinizer_Registration.Root rvalue = await scrutinizerUnits.Test_ScrutRegistration();
            scrut_UserId = rvalue.data.UserID;
            scrut_rowid = rvalue.data.rowid;
        }
        public async Task Test_CompanyRegistration()
        {
            var someval = await _objcom.Post_Registration(Company.Registration(RTAAudId));
            userid = someval.data.UserID;
            //Assert.AreEqual("New Registration completed Successfully", check.data.Message);
        } 

     
        public async Task Test_CompanyLogin()
        {
            var someval= await _objcom.Post_Login(Company.Default_user(userid));
            //Assert.IsNotNull(check.Message);
            //Assert.AreEqual("User logged in succesfuly", check.Message);
            token = someval.data.Token;
        }
      
        public async Task Test_postdownloadagreement()
        {
            var check = await _objcom.Post_Docdownload("tri_partiate_agreement", token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            docno = jsonparsingcls1.Data.doc_no;
            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);

        }
      
        public async Task Test_uploadagreement()
        {
            var check = await _objcom.Post_DocUpload(Company.Docupload(docno), token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
            // Assert.IsNotNull(check.Message);
            // Assert.AreEqual("User logged in succesfuly", check.Message);
        }
     
        public async Task Test_getdownloadagreement()
        {
            var check = await _objcom.Get_Docdownload(token);
            //Assert.IsNotNull(check.Message);
            // Assert.AreEqual(200, check.statusCode);
        }
     
        public async Task Test_Postgenerateevent()
        {
            var check = await _objcom.Post_GenerateEvent(Company.generate_event(scrut_rowid),token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            event_id = jsonparsingcls1.Data.event_id;
        }
      
        public async Task Test_Geteventlistcurrent()
        {
            var check = await _objcom.Get_EventList("current", token);
            string msg = check.message;
        }
     
        public async Task Test_Putgenerateevent()
        {
            var check = await _objcom.Put_Company_Eventdetails(Company.Com_event_detail(event_id, scrut_rowid), token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }
        //[SetUp]
        //[Test, Order(10)]
        //public async Task Test_PostFileUpload()
        //{
        //    var check = await _objcom.Post_FileUpload(token);
        //    jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    filedocid = jsonparsingcls1.Data.doc_id;
        //}

       
        public void romuploadfile_eventid_change()
        {
            
           // string filepath = "C:\\Evoting-Github\\Files\\200520001_84382_15-06-2020_120609_final_excel-LMEL-15.06.2020.zip";
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
    
        public async Task Test_PostNewgeneratedFileUpload()
        {
            var check = await _objcom.Post_FileUploadnew(token, fileLocMove);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            filedocid = jsonparsingcls1.Data.doc_id;
        }

      
        public async Task Test_postROMupload()
        {
            var check = await _objcom.Post_Rom_Upload(Company.romupload(event_id, filedocid), token);
             string msg = check.message;
        }

        
        public async Task Test_postApprovedEvent()
        {
            var check = await _objcom.PostApproved_Event(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.Data.remark;
        }
        //[SetUp]
        //[Test, Order(15)]
        //public async Task Test_Geteventlistapproved()
        //{
        //    var check = await _objcom.Get_EventList("approved", token);
        //    Assert.AreEqual(200, check.statusCode);
        //    jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    string msg = jsonparsingcls1.message;
        //}

      
        public async Task callRTAsecond()
        {
            RTAUnitTest rTAUnitTest = new RTAUnitTest(event_id);
            await rTAUnitTest.Test_RTALogin(RTAUserId);
            await rTAUnitTest.Test_postdownloadagreement();
            await rTAUnitTest.Test_uploadagreement();
            await rTAUnitTest.Test_getdownloadagreement();
            await rTAUnitTest.Test_Geteventlistcurrent();
            await rTAUnitTest.Test_Putgenerateevent();
            rTAUnitTest.romuploadfile_eventid_change();
            await rTAUnitTest.Test_PostNewgeneratedFileUpload();
            await rTAUnitTest.Test_postROMupload();
            await rTAUnitTest.Test_PostFileUpload(); 
            await rTAUnitTest.Test_postApprovedEvent();
            await rTAUnitTest.Test_Geteventlistapproved();
        }
        
        public async Task callScrutinizersecond()
        {
            ScrutinizerUnitTest scrutinizerUnit = new ScrutinizerUnitTest(event_id);
            await scrutinizerUnit.Test_ScrutLogin(scrut_UserId);
            await scrutinizerUnit.Test_postdownloadagreement();
            await scrutinizerUnit.Test_uploadagreement();
            await scrutinizerUnit.Test_getdownloadagreement();
            await scrutinizerUnit.Test_PostScrutVotingRestrict();
            await scrutinizerUnit.Post_UnblockEvent();
            await scrutinizerUnit.Post_finalizeevent();
            await scrutinizerUnit.Get_reportsgeneration();
        }
     
        public async Task callInvestor()
        {
            InvestorUnitTest investorUnit = new InvestorUnitTest(event_id);
            await investorUnit.Test_InvestorLogin();
            await investorUnit.Post_InvestorVoting();
        }

        public async Task callCustRegistration()
        {
            CustodianUnitTest ObjCusto = new CustodianUnitTest(event_id);
            Custodian_Module.Custodian_Registration.Root rvalue = await ObjCusto.Test_CustodianRegistration();
            Cust_UserId = rvalue.data.UserID;
            Cust_rowid = rvalue.data.aud_id;
        }

        public async Task callCustodion()
        {
            CustodianUnitTest ObjCusto = new CustodianUnitTest(event_id);
            await ObjCusto.Test_CustodianLogin(Cust_UserId);
            await ObjCusto.Test_CustodianFileUpload();
            await ObjCusto.Test_CustodianPOAUpload();


        }
    }
}