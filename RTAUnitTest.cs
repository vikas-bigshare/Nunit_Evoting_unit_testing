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
    //[TestFixture]
  public  class RTAUnitTest
    {
       
        public RTAUnitTest(string event_ids)
        {
            this.event_id = event_ids;
        }


        RTA _objcom = new RTA();
       
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

        public async Task<RTA_Module.RTA_Registration.Root> Test_RTARegistration()
        {
            var check = await _objcom.Post_Registration(RTA.Registration());
            return JsonConvert.DeserializeObject<RTA_Module.RTA_Registration.Root>(check);
       
        }
        public async Task Test_RTALogin(string RTAuserId)
        {
            var check = await _objcom.Post_Login(RTA.Default_user(RTAuserId));
            RTA_Module.RTA_Login.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_Login.Root>(check);
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
       
      
        public async Task Test_Geteventlistcurrent()
        {
            var check = await _objcom.Get_EventList("past", token);
            Assert.AreEqual(200, check.statusCode);
        }
     
        public async Task Test_Putgenerateevent()
        {
            var check = await _objcom.Put_UpdateEven(RTA.Update_Event(event_id),token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.message;
        }
    
        public async Task Test_PostFileUpload()
        {
            var check = await _objcom.Post_FileUpload(token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            filedocid = jsonparsingcls1.Data.doc_id;
        }

        public void romuploadfile_eventid_change()
        {
            //string event_id = "157";
            string filepath = "C:\\Evoting-Github\\Files\\CDSLForTest.txt";
            string Romfile = "C:\\Evoting-Github\\Rom_uploadedFiles\\";
            using (StreamReader sr = new System.IO.StreamReader(filepath))
            {
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
            var check = await _objcom.Post_Rom_Upload(RTA.romupload(event_id, filedocid), token);
            string msg = check.message;
        }
       
        public async Task Test_postApprovedEvent()
        {
            var check = await _objcom.PostApproved_Event(event_id, token);
            jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            string msg = jsonparsingcls1.Data.remark;
        }
     
        public async Task Test_Geteventlistapproved()
        {
            var check = await _objcom.Get_EventList("approved", token);
            Assert.AreEqual(200, check.statusCode);
            //jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
            //jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
            //string msg = jsonparsingcls1.message;
        }

    }
}
