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
            RTA_Module.RTA_postdownloadagreement.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_postdownloadagreement.Root>(check);
            docno = someval.data.doc_no;
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }
        public async Task Test_uploadagreement()
        {
            var check = await _objcom.Post_DocUpload(Company.Docupload(docno), token);
            RTA_Module.RTA_uploadagreement.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_uploadagreement.Root>(check);
            Assert.IsNotNull(someval.message);
        }
        public async Task Test_getdownloadagreement()
        {
            var check = await _objcom.Get_Docdownload(token);
            Assert.IsNotNull(check.message);
            Assert.AreEqual(200, check.statusCode);
        }
        public async Task Test_Geteventlistcurrent()
        {
            var check = await _objcom.Get_EventList("past", token);
            Assert.AreEqual(200, check.statusCode);
        }
        public async Task Test_Putgenerateevent()
        {
            var check = await _objcom.Put_UpdateEven(RTA.Update_Event(event_id),token);
            RTA_Module.RTA_Putgenerateevent.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_Putgenerateevent.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual(200, someval.statusCode);
        }
        //public async Task Test_PostFileUpload()
        //{
        //    var check = await _objcom.Post_FileUpload(token);
        //    RTA_Module.RTA_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_PostNewGeneratedfile.Root>(check);
        //    Assert.IsNotNull(someval.message);
        //    Assert.IsNotNull(someval.data.doc_id);
        //    filedocid = someval.data.doc_id;
        //}
        public void romuploadfile_eventid_change()
        {
            // string filepath = "C:\\Evoting-Github\\Files\\CDSLForTest.txt";
            string filepath = "C:\\Evoting-Github\\Files\\RTA_Rom10record.txt";
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
            RTA_Module.RTA_PostNewGeneratedfile.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_PostNewGeneratedfile.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.IsNotNull(someval.data.doc_id);
            filedocid = someval.data.doc_id;
        }
        public async Task Test_postROMupload()
        {
            var check = await _objcom.Post_Rom_Upload(RTA.romupload(event_id, filedocid), token);
            RTA_Module.RTA_PostROMUpload.Root someval = JsonConvert.DeserializeObject<RTA_Module.RTA_PostROMUpload.Root>(check);
            Assert.IsNotNull(someval.message);
            Assert.AreEqual("ROM Uploaded succesfully", someval.data.Remark);
            string msg = someval.message;
        }
        //public async Task Test_postApprovedEvent()
        //{
        //    var check = await _objcom.PostApproved_Event(event_id, token);
        //    jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    string msg = jsonparsingcls1.Data.remark;
        //}
     
        //public async Task Test_Geteventlistapproved()
        //{
        //    var check = await _objcom.Get_EventList("approved", token);
        //    Assert.AreEqual(200, check.statusCode);
        //    //jsonparsingcls jsonparsingcls1 = new jsonparsingcls();
        //    //jsonparsingcls1 = JsonConvert.DeserializeObject<jsonparsingcls>(check);
        //    //string msg = jsonparsingcls1.message;
       // }

    }
}
